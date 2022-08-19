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

        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted,CanCloseApplicationCommandExecute);

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
