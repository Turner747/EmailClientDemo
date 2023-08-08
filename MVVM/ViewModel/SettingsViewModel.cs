using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class SettingsViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public RelayCommand NavigateToHomeCommand { get; set; }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel(INavigationService navigation)
        {
            Navigation = navigation;

            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => { return true; });
        }
    }
}
