using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToSettingsCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => { return true; });
            NavigateToSettingsCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => { return true; });
        }
    }
}
