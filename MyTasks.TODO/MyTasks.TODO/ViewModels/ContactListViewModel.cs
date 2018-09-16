using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using MyTasks.TODO.Models;
using System.Collections.ObjectModel;
using System;

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ContactListViewModel : FreshMvvm.FreshBasePageModel
    {
        public ContactListViewModel()
        {
            Title = "Contacts";
        }

        public ObservableCollection<Contact> Contacts { get; set; }

        public string Title { get; set; }

        public override void Init(object initData)
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact() {  Id = 0, Name= "Captain America", Phone="415.480.9299" });
            Contacts.Add(new Contact() { Id = 1, Name = "Captain America", Phone = "415.480.9299" });
            Contacts.Add(new Contact() { Id = 2, Name = "Captain America", Phone = "415.480.9299" });
            Contacts.Add(new Contact() { Id = 3, Name = "Captain America", Phone = "415.480.9299" });
            Contacts.Add(new Contact() { Id = 4, Name = "Captain America", Phone = "415.480.9299" });
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }


    }
}