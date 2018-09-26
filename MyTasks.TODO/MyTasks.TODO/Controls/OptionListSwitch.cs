using MyTasks.TODO.Models;
using System;
using Xamarin.Forms;

namespace MyTasks.TODO.Controls
{
    public class OptionListSwitch : Switch
    {
        public static readonly BindableProperty OptionListItemProperty 
                                    = BindableProperty.Create(
                                        propertyName: "OptionListItem",
                                        returnType: typeof(OptionItem),
                                        declaringType: typeof(OptionListSwitch),
                                        defaultValue: null);

        public OptionItem OptionListItem
        {
            get
            {
                return (OptionItem)GetValue(OptionListItemProperty);
            }
            set
            {
                SetValue(OptionListItemProperty, value);
            }
        }
    }
}
