﻿namespace HospitalApp.ViewModel
{
    //using Services;

    public class MainViewModel
    {
        //public DialogService DialogService { get; set; }
        //public ApiService ApiService { get; set; }

        public MainViewModel()
        {
            //DialogService = new DialogService();
            //ApiService = new ApiService();
        }

        #region Singleton
        private static MainViewModel _instance;

        public static MainViewModel GetInstance()
        {
            return _instance ?? (_instance = new MainViewModel());
        }
        #endregion
    }
}