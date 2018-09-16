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

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ToDoListViewModel : FreshMvvm.FreshBasePageModel
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
                UserDialogs.Instance.HideLoading();
            });

        }

        private async Task<ObservableCollection<TodoItem>> InvokeTodoApi()
        {
            var response = RestService.For<ITaskToDoApi>(Config.ApiUrl);
            return await response.GetTodoItems();
        }

    }
}