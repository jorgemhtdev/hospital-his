namespace HospitalApp.Views
{
    using HospitalApp.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddDoctorView : ContentPage
	{
		public AddDoctorView()
		{
			InitializeComponent ();
            BindingContext = new NewDoctorViewModel();
		}
	}
}