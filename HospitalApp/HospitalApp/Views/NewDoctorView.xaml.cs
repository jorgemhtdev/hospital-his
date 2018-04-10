namespace HospitalApp.Views
{
    using HospitalApp.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewDoctorView : ContentPage
	{
		public NewDoctorView ()
		{
			InitializeComponent ();
            BindingContext = new NewDoctorViewModel();
		}
	}
}