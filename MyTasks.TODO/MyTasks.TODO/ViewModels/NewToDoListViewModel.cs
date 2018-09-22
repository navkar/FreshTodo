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
    public class NewToDoListViewModel : BaseViewModel
    {
        public ICommand SaveToDoCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        private IUserDialogs userDialogs;
        public NewToDoListViewModel(IUserDialogs dialogs) : base(dialogs)
        {
            Title = "New TODO";
            userDialogs = dialogs;
            SaveToDoCommand = new Command(
                async () => {
                    var todoItem = new TodoItem { Text = ToDoText, Id = System.DateTime.UtcNow.Ticks.ToString() };
                    await RunSafe(SaveData(todoItem));
                    await CoreMethods.PopPageModel(true);
                });

            GoBackCommand = new Command(
                async () => {
                    await CoreMethods.PopPageModel(true);
                });
        }
        public ObservableCollection<TodoItem> ToDoItems { get; set; }

        public string Title { get; set; }

        public string ToDoText { get; set; }

        public override void Init(object initData)
        {
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }
        
        async Task SaveData(TodoItem item)
        {
            var itemResponse = await ApiManager.AddToDoItemsAsync(item);
            if (!itemResponse.IsSuccessStatusCode)
            {
                await UserDialogs.Instance.AlertAsync(string.Format("reason: {0}", itemResponse.ReasonPhrase), "Error", "Ok");
                return;
            }

            await UserDialogs.Instance.AlertAsync("Saved.", "Success", "OK");
        }
    }
}