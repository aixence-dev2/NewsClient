using NewsAPI.Models;
using NewsClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace NewsClient.ViewModels
{
    public class NewsViewModel:ViewModelBase
    {
        private readonly NewsService _newsService = new NewsService();

        private ObservableCollection<Article> _ukraine = new ObservableCollection<Article>();
        private ObservableCollection<Article> _poland = new ObservableCollection<Article>();
        private ObservableCollection<Article> _england = new ObservableCollection<Article>();
        private Visibility _ukraineNewsVisibility = Visibility.Collapsed;
        private Visibility _polandNewsVisibility = Visibility.Collapsed;
        private Visibility _englandNewsVisibility = Visibility.Collapsed;
        private DispatcherTimer updateNewsTimer = new DispatcherTimer();


        public ObservableCollection<Article> Ukraine
        {
            get => _ukraine;
            set
            {
                _ukraine = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Article> Poland
        {
            get => _poland;
            set
            {
                _poland = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Article> England
        {
            get => _england;
            set
            {
                _england = value;
                OnPropertyChanged();
            }
        }

        public Visibility UkraineNewsVisibility
        {
            get => _ukraineNewsVisibility;
            set
            {
                _ukraineNewsVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility PolandNewsVisibility
        {
            get => _polandNewsVisibility;
            set
            {
                _polandNewsVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility EnglandNewsVisibility
        {
            get => _englandNewsVisibility;
            set
            {
                _englandNewsVisibility = value;
                OnPropertyChanged();
            }
        }

        public NewsViewModel()
        {
            updateNewsTimer.Interval = TimeSpan.FromMinutes(10);
            updateNewsTimer.Tick += (sender, e) =>
            {
                InitializeData();
            };
            updateNewsTimer.Start();
            InitializeData();
        }

        private async void InitializeData()
        {
            Ukraine = await _newsService.GetUkraineNews();
            if (Ukraine.Count > 0)
            {
                UkraineNewsVisibility = Visibility.Visible;
            }
            Poland = await _newsService.GetPolandNews();
            if (Poland.Count > 0)
            {
                PolandNewsVisibility = Visibility.Visible;
            }
            England = await _newsService.GetEnglandNews();
            if (England.Count > 0)
            {
                EnglandNewsVisibility = Visibility.Visible;
            }
        }
    }
}
