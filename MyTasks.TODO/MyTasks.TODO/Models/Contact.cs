using System;
using System.Collections.Generic;
using System.Text;

namespace MyTasks.TODO.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
