using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public RelayCommand NavigateToSettingsCommand { get; set; }

        public INavigationService Navigation 
        { 
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;

            NavigateToSettingsCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => { return true; });
        }
    }
}
