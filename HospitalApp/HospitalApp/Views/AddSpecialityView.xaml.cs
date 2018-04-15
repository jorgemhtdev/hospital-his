namespace HospitalApp.Views
{
    using HospitalApp.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddSpecialityView : ContentPage
	{
		public AddSpecialityView ()
		{
			InitializeComponent ();
            BindingContext = new AddSpecialityViewModel();
		}
	}
}