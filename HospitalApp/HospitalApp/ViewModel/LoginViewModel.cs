namespace HospitalApp.ViewModel
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using global::Model.Request;
    using HospitalApp.Helpers;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isToggled;
        #endregion

        #region Properties
        public string Email
         {
             get => email;
             set => SetProperty(ref email, value);
         }
         public string Password
         {
             get => password;
             set => SetProperty(ref password, value);
         }
        public bool IsToggled
        {
            get => isToggled;
            set => SetProperty(ref isToggled, value);
        }
        #endregion


        #region Constructor
        public LoginViewModel()
        {
            IsToggled = true;
        }
        #endregion

        #region Command
        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            var user = new UserRequest()
            {
                Email = Email,
                Password = Password
            };

            if(string.IsNullOrEmpty(Email))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes rellenar el email");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes rellenar la password");
                return;
            }

            if (await MainViewModel.GetInstance().ApiService.UserProfile(user) == null) return;

            Settings.IsLogin = IsToggled;

            MainViewModel.GetInstance().Navigation.SetMainPage("MasterView");
        }
        #endregion
    }
}
