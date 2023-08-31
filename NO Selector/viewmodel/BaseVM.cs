using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NO_Selector.viewmodel
{
    public partial class BaseVM : ObservableObject
    {
        [ObservableProperty]
        private string title;

        public BaseVM()
        {
            Title = "Number Opener Selector";
        }
    }
}
//This comment is added by Ammar
