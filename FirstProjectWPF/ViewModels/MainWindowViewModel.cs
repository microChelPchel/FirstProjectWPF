﻿using FirstProjectWPF.Infrastructure;
using FirstProjectWPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace FirstProjectWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
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
        }


    }
}
