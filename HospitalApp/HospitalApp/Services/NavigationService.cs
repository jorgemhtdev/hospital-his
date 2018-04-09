namespace HospitalApp.Services
{
    using HospitalApp.Helpers;
    using System;
    using System.Threading.Tasks;
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

        public async Task NavigateOnDetailView(string pageName)
        {
            switch (pageName)
            {
                case "NewSpecialityView":
                    await App.Navigator.PushAsync(new NewSpecialityView());
                    break;
                case "NewDoctorView":
                    await App.Navigator.PushAsync(new NewDoctorView());
                    break;
            }
        }

        public async Task NavigateOnMasterView(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)                                                                                                                                                                                                                                                             
            {
                case "UserView":
                    await App.Navigator.PushAsync(new UserView());
                    break;
                case "LogoutAccount":
                    Application.Current.MainPage = new LoginView();
                    Logout();
                    break;
            }
        }
        #endregion

        #region

        private void Logout()
        {
            Settings.AccessToken = String.Empty;
            Settings.IsLogin = false;
        }

        #endregion
    }
}