using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MyTasks.TODO.Services;

namespace MyTasks.TODO.ViewModels
{
    public class BaseViewModel : FreshMvvm.FreshBasePageModel
    {
        public IApiManager ApiManager;
        IApiService<ITaskToDoApi> todoApi = new ApiService<ITaskToDoApi>(Config.ApiUrl);
        public IUserDialogs PageDialog = null;

        public bool IsBusy { get; set; }
        public BaseViewModel(IUserDialogs dialogs)
        {
            ApiManager = new ApiManager(todoApi);
            PageDialog = dialogs;
        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadingMessage = null)
        {
            try
            {
                if (IsBusy) return;
                Debug.WriteLine("Run Safe - begin try");
                IsBusy = true;
                if (ShowLoading) PageDialog.ShowLoading(loadingMessage ?? "Loading");
                await task;
                Debug.WriteLine("Run Safe - end try");
            }
            catch (Exception e)
            {
                IsBusy = false;
                PageDialog.HideLoading();
                Debug.WriteLine(e.Message + e.StackTrace);
                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "OK");
            }
            finally
            {
                Debug.WriteLine("Run Safe - finally");
                IsBusy = false;
                if (ShowLoading) PageDialog.HideLoading();
            }
        }
    }
}
