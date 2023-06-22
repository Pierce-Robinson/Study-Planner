using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMA.Core;

namespace TMA.MVVM.ViewModel
{
    public class MainWinViewModel : ObservableObject
    {
        //commands
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ReportViewCommand { get; set; }
        public RelayCommand TimeStudiedViewCommand { get; set; }
        public RelayCommand AddModuleViewCommand { get; set; }


        //propertys
        public HomeViewModel HomeVM { get; set; }
        public ReportViewModel ReportVM { get; set; }
        public TimeStudiedViewModel TimeVM { get; set; }
        public AddModuleViewModel AddModuleVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }
        private string _testString;
        public string TestString
        {
            get => _testString;
            set
            {
                if (value == _testString) return;
                _testString = value;
                OnPropertyChanged();
            }
        }
        public MainWinViewModel()
        {
            HomeVM = new HomeViewModel();
            ReportVM = new ReportViewModel();
            AddModuleVM = new AddModuleViewModel();
            TimeVM = new TimeStudiedViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ReportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReportVM;
            });

            AddModuleViewCommand = new RelayCommand(o =>
            {
                CurrentView = AddModuleVM;
            });

            TimeStudiedViewCommand = new RelayCommand(o =>
            {
                CurrentView = TimeVM;
            });
            TestString = "Test string.";
        }

        

       


    }
}
