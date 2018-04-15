namespace HospitalApp.ViewModel
{
    using Services;

    public class MainViewModel
    {
        #region Properties
        public DialogService DialogService { get; set; }
        public ApiService ApiService { get; set; }
        public NavigationService Navigation { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            DialogService = new DialogService();
            ApiService = new ApiService();
            Navigation = new NavigationService();
        }
        #endregion

        #region Singleton
        private static MainViewModel _instance;

        public static MainViewModel GetInstance()
        {
            return _instance ?? (_instance = new MainViewModel());
        }
        #endregion
    }
}
