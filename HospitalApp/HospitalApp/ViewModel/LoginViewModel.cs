namespace HospitalApp.ViewModel
{
    using Model.Request;

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

        public LoginViewModel()
        {
            IsToggled = true;
        }

        #region Command

        private void Login()
        {
            var user = new TokenRequest()
            {
                Email = Email,
                Password = Password
            };

        }
        #endregion
    }
}
