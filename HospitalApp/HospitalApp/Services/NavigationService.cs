namespace HospitalApp.Services
{
    using Views;
    using Xamarin.Forms;

    public class NavigationService
    {
        #region Methods
        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterView":
                    Application.Current.MainPage = new MasterView();
                    break;
            }
        }
        #endregion
    }
}