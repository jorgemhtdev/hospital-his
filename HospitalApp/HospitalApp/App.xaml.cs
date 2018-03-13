namespace HospitalApp
{
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
	{
	    #region Properties
	    public static NavigationPage Navigator { get; set; }
	    public static MasterView Master { get; set; }
	    #endregion

        public App ()
		{
			InitializeComponent();

			MainPage = new LoginView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
