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

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ToDoListViewModel : BaseViewModel
    {
        public ToDoListViewModel()
        {
            Title = "To Do List";
            ToDoItems = new ObservableCollection<TodoItem>();
        }

        public ObservableCollection<TodoItem> ToDoItems { get; set; }

        public string Title { get; set; }

        public override void Init(object initData)
        {
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            Task.Run(async () => {
                UserDialogs.Instance.ShowLoading();
                ToDoItems = await InvokeTodoApi();
                //await GetData();
                UserDialogs.Instance.HideLoading();
            });
        }

        async Task GetData()
        {
            var makeUpsResponse = await ApiManager.GetToDoItemsAsync();
            if (makeUpsResponse.IsSuccessStatusCode)
            {
                var response = await makeUpsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<List<TodoItem>>(response));
                ToDoItems = new ObservableCollection<TodoItem>(json);
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }

        private async Task<ObservableCollection<TodoItem>> InvokeTodoApi()
        {
            var response = RestService.For<ITaskToDoApi>(Config.ApiUrl);
            return await response.GetTodoItemsDirect();
        }
    }
}