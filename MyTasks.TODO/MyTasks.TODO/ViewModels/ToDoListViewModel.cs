using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using MyTasks.TODO.Models;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using Refit;
using MyTasks.TODO.Services;
using Acr.UserDialogs;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Input;
using System.Diagnostics;

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ToDoListViewModel : BaseViewModel
    {
        public ICommand GetDataCommand { get; set; }

        public ToDoListViewModel(IUserDialogs dialogs) : base(dialogs)
        {
            Title = "ToDo List";
            ToDoItems = new ObservableCollection<TodoItem>();
            GetDataCommand = new Command(async () => await RunSafe(GetData()));
        }
        public ObservableCollection<TodoItem> ToDoItems { get; set; }

        public string Title { get; set; }

        public override void Init(object initData)
        {
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            Task.Run(async () =>
            {
                //await RefreshToDoData();
                await RunSafe(GetData());
            });
        }

        private async Task RefreshToDoData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                ToDoItems = await InvokeTodoApi();
            }
            catch (Exception e)
            {
                Debug.WriteLine("message: " + e.Message + e.StackTrace);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        async Task GetData()
        {
            var itemsResponse = await ApiManager.GetToDoItemsAsync();
            if (!itemsResponse.IsSuccessStatusCode)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("reason: {0}", itemsResponse.ReasonPhrase), "Error", "Ok");
                return;
            }

            var response = await itemsResponse.Content.ReadAsStringAsync();
            var json = await Task.Run(() => JsonConvert.DeserializeObject<List<TodoItem>>(response));
            ToDoItems = new ObservableCollection<TodoItem>(json);
        }

        private async Task<ObservableCollection<TodoItem>> InvokeTodoApi()
        {
            var response = RestService.For<ITaskToDoApi>(Config.ApiUrl);
            return await response.GetTodoItemsDirect();
        }
    }
}