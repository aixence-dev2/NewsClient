using NewsClient.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewsClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Page _currentContext;

        public Page CurrentContext
        {
            get => _currentContext;
            set
            {
                _currentContext = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CurrentContext = new NewsPage();
        }      
    }
}
