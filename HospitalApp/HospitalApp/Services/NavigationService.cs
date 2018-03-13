using System.Threading.Tasks;

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
        public async Task NavigateOnMaster(string pageName)
        {
            App.Master.IsPresented = true;

            switch (pageName)
            {
                case "#":
                    //await App.Navigator.PushAsync();
                    break;
                case "##":
                    //Logout();
                    break;
            }
        }
        #endregion

    }
}