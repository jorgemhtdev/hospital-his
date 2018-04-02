namespace HospitalApp.Services
{
    using HospitalApp.Helpers;
    using HospitalApp.ViewModel;
    using Model;
    using Model.Request;
    using Plugin.Connectivity;
    using System.Threading.Tasks;

    public class ApiService : HttpService
    {
        #region users
        public async Task<UserResponse> UserProfile(UserRequest user)
        {
            if (!await IsConnection())
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No dispones de conexión a internet");
                return null;
            }

            var token = await GetToken(user.Email, user.Password);

            if(token == null || token.AccessToken == null)
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Revisa tus credenciales");
                return null;
            }

            //var userResponse = await Post(, user);

            var userResponse = new UserResponse()
            {
                Email = user.Email
            };

            Settings.AccessToken = token.AccessToken;

            return userResponse;

        }
        #endregion

        #region Methods
        public async Task<bool> IsConnection()
        {

            if (!CrossConnectivity.Current.IsConnected) return false;

            if (!await CrossConnectivity.Current.IsRemoteReachable("google.com")) return true;

            return true;
        }
        #endregion
    }
}
