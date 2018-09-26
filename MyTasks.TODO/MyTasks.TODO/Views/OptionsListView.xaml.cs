using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTasks.TODO.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsListView 
	{
        static List<string> DefaultList = new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5",
                "Item 6"
            };

        public OptionsListView ()
		{
			InitializeComponent();
            this.BindingContext = this;
        }
        
        #region bindable properties
        public static readonly BindableProperty QnAOptionsProperty =
          BindableProperty.Create(propertyName: nameof(OptionList),
          returnType: typeof(List<string>),
          declaringType: typeof(OptionsListView),
          defaultValue: DefaultList);

        #endregion

        #region public properties

        public List<string> OptionList
        {
            get
            {
                return (List<string>)GetValue(QnAOptionsProperty);
            }
            set
            {
                SetValue(QnAOptionsProperty, value);
                UXOptionsList.ItemsSource = OptionList;
            }
        }

        #endregion
    }
}