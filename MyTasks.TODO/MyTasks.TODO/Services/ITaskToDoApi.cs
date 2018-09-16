using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyTasks.TODO.Models;
using Refit;

namespace MyTasks.TODO.Services
{
    [Headers("Content-Type: application/json")]
    public interface ITaskToDoApi
    {
        [Get("/dev/UserNotesLamba")]
        Task<ObservableCollection<TodoItem>> GetTodoItems();
    }
}
