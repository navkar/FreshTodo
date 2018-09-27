using MyTasks.TODO.Models;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SwipeCardsViewModel : FreshMvvm.FreshBasePageModel
    {
        public string Title { get; set; } = "Swipe Cards View";

        public int CurrentPositionIndex { get; set; } = 0;
                
        public Command ItemTappedCommand { get; set; }
        
        public Command NextQuestionCommand { get; set; }
        
        public ObservableCollection<DeckItem> Cards { get; set; }
        public SwipeCardsViewModel()
        {
            ItemTappedCommand = new Command<string>((item) =>
               {
                   Console.WriteLine("SelectOptionCommand: " + item.ToString());
                   //CoreMethods.DisplayAlert("Exception", item, "OK");
               });

            NextQuestionCommand = new Command<int>((index) =>
            {
                IList<int> selectedAnswers = Cards[CurrentPositionIndex].Options.Where(x => x.IsSelected == true).Select(x => x.Id).ToList();

                var intersection = Cards[CurrentPositionIndex].Answers.Intersect(selectedAnswers);

                if (intersection.Count() != Cards[CurrentPositionIndex].Answers.Count)
                {
                    CoreMethods.DisplayAlert("Incorrect", "Check your answers again!", "OK");
                }
                else
                {
                    CoreMethods.DisplayAlert("Correct", "Looks great!", "OK");
                }
                
            });
            
            Task.Run(() => {
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
                        Cards = new ObservableCollection<DeckItem>();
                        Cards.Add(new DeckItem() { Id = 0, QuestionText = "No Questions were found." });
                    }

                    Title = deck.DeckTitle;
                    Cards = deck.DeckItems;
                }
                catch(Exception ex)
                {
                    CoreMethods.DisplayAlert("Exception", ex.Message, "OK");
                }
            });
        }
    }
}