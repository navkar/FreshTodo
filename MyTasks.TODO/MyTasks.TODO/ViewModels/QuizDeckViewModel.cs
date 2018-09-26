using MyTasks.TODO.Models;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class QuizDeckViewModel : FreshMvvm.FreshBasePageModel
    {
        public string Title => "QuizDeck View";
        public ObservableCollection<DeckItem> Cards { get; set; }
        public QuizDeckViewModel()
        {
            Task.Run(() => {
                LoadQnAJson();
            });
        }

        private void LoadQnAJson()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SwipeCardsViewModel)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("MyTasks.TODO.Data.qa_deck.json");
                string json = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }

                if (string.IsNullOrEmpty(json)) return;
                QuizDeck deck = JsonConvert.DeserializeObject<QuizDeck>(json);
                if (deck == null)
                {
                    Cards = new ObservableCollection<DeckItem>
                    {
                        new DeckItem() { Id = 0, QuestionText = "No Questions were found." }
                    };
                }

                Cards = deck.DeckItems;
            }
            catch (Exception ex)
            {
                CoreMethods.DisplayAlert("Exception", ex.Message, "OK");
            }
        }

    }
}