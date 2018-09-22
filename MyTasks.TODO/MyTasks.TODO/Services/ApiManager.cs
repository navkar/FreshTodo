using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Fusillade;
using MyTasks.TODO.Models;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Polly;
using Refit;

namespace MyTasks.TODO.Services
{
    public class ApiManager : IApiManager
    {
        IConnectivity _connectivity = CrossConnectivity.Current;
        IApiService<ITaskToDoApi> todoApi;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public ApiManager(IApiService<ITaskToDoApi> todoApi)
        {
            this.todoApi = todoApi;
            IsConnected = _connectivity.IsConnected;
            _connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if (!e.IsConnected)
            {
                // Cancel All Running Task
                var items = runningTasks.ToList();
                foreach (var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }

        public async Task<HttpResponseMessage> GetToDoItemsAsync()
        { 
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(todoApi.GetApi(Priority.UserInitiated).GetTodoItems(cts.Token));
            return await task;
        }

        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
                    where TData : HttpResponseMessage,
                    new()
        {
            TData data = new TData();

            if (!IsConnected)
            {
                var strngResponse = "No network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                UserDialogs.Instance.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            IsReachable = await _connectivity.IsRemoteReachable(Config.ApiHostName);

            if (!IsReachable)
            {
                var strngResponse = "No internet connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                UserDialogs.Instance.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            data = await Policy
            .Handle<WebException>()
            .Or<ApiException>()
            .Or<TaskCanceledException>()
            .WaitAndRetryAsync
            (
                retryCount: 1,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            )
            .ExecuteAsync(async () =>
            {
                var result = await task;

                Debug.WriteLine("[Status Code] " + result.StatusCode);

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                
                }
                runningTasks.Remove(task.Id);

                return result;
            });

            return data;
        }

        public async Task<HttpResponseMessage> AddToDoItemsAsync(TodoItem item)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(todoApi.GetApi(Priority.UserInitiated).AddTodoItem(item));
            return await task;
        }
    }
}
