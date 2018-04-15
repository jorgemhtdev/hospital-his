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
                    await App.Navigator.PushAsync(new AddSpecialityView());
                    break;
                case "AddDoctorView":
                    await App.Navigator.PushAsync(new AddDoctorView());
                    break;
            }
        }

        public async Task BackOnDetailView()
        {
            await App.Navigator.PopToRootAsync();
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