namespace HospitalApp.ViewModel
{
    using Xamarin.Forms;

    public class UserViewModel : BaseViewModel
    {
        public int RowDefinitionOne { get; set; }
        public int TranslationY { get; set; }
        #region Constructor
        public UserViewModel()
        {
            Title = "Perfil";
            LoadRow();
        }
        #endregion 

        private void LoadRow()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    RowDefinitionOne = 200;
                    TranslationY = 160;
                    break;
                case Device.Android:
                    RowDefinitionOne = 160;
                    TranslationY = 120;
                    break;
                default:
                    RowDefinitionOne = 180;
                    break;
            }
        }
    }
}
