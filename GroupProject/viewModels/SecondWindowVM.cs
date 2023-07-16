using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.viewModels
{
    public partial class SecondWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string? usName;

        [RelayCommand]
        public void menu1Show()
        {

        }

        public void menu3Show()
        {

        }
    }
}
