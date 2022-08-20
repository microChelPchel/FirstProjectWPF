using FirstProjectWPF.Infrastructure;
using FirstProjectWPF.Models;
using FirstProjectWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace FirstProjectWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region
        /// <summary>Номер выбранной вкладки</summary>
        private int _SelectedPageIndex=0;

        /// <summary>Номер выбранной вкладки</summary>
        public int SelectedPageIndex
        {
            get =>_SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }
        #endregion




        #region TestDataPoints
        private IEnumerable<DataPoint> _testDataPoints;

        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set =>Set(ref _testDataPoints, value);
        }

        #endregion


        #region head title
        private string _Title= "Анализ статистики covid";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        
        }

        #endregion


        #region Status : string - status application

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

        #region Commands
        #region Close Command
        public ICommand CloseApplicationCommand { get;  }

        private bool CanCloseApplicationCommandExecute(object parametr) => true;

        private void OnCloseApplicationCommandExecuted(object parametr) 
        {
            Application.Current.Shutdown();
        }
        #endregion

        
        public ICommand ChangeTabIngexCommand { get; }

        public bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        public void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted,CanCloseApplicationCommandExecute);
            ChangeTabIngexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }
            TestDataPoints = data_points;
        }

        //4:01

    }
}
