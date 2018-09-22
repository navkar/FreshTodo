using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTasks.TODO.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public string CreatedOn => DateTime.UtcNow.ToShortDateString();
    }
}
