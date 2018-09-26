using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTasks.TODO.Models
{
    public class QuizDeck
    {
        public ObservableCollection<DeckItem> DeckItems { get; set; }
    }
}
