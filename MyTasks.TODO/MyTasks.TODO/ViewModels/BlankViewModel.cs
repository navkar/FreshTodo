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
    public class BlankViewModel : FreshMvvm.FreshBasePageModel
    {
        public string Title => "Blank View";
        public BlankViewModel()
        {

        }
    }
}