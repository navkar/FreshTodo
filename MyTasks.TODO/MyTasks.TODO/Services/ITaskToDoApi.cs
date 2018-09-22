using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyTasks.TODO.Models;
using Refit;

namespace MyTasks.TODO.Services
{
    [Headers("Content-Type: application/json")]
    public interface ITaskToDoApi
    {
        [Get("/dev/UserNotesLamba")]
        Task<ObservableCollection<TodoItem>> GetTodoItemsDirect();

        [Get("/dev/UserNotesLamba")]
        Task<HttpResponseMessage> GetTodoItems(CancellationToken cancellationToken);

        [Post("/dev/UserNotesLamba")]
        Task<HttpResponseMessage> AddTodoItem([Body] TodoItem todoItem);

        [Post("/dev/UserNotesLamba")]
        Task<HttpResponseMessage> AddBuffTodoItem([Body(buffered: true)] TodoItem todoItem);
    }
}
