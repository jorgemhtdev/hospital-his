namespace HospitalApp.Views
{
    using ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserView : ContentPage
	{
		public UserView ()
		{
			InitializeComponent ();
		    BindingContext = new UserViewModel();
		}
	}
}