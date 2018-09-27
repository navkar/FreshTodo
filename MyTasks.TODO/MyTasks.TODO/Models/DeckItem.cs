using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyTasks.TODO.Models
{
    public class DeckItem
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public IList<OptionItem> Options { get; set; }
        public bool IsMultiOption { get; set; } = true;
        public IList<int> Answers { get; set; }

        [JsonIgnore]
        public int NoOfOptions => Options.Count;

        [JsonIgnore]
        public IList<int> SelectedAnswers { get; set; }

        [JsonIgnore]
        public string DisplayQuestion => string.Format("{0}. {1}", Id, QuestionText);
    }

    public class OptionItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public bool IsSelected { get; set; }

        [JsonIgnore]
        public string DisplayOption => string.Format("{0}. {1}", Id, Text);
    }

    public class SelectableItemWrapper<T>
    {
        public bool IsSelected { get; set; }
        public T Item { get; set; }
    }
}
