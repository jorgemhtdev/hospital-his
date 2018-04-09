namespace HospitalApp.Views
{
    using HospitalApp.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecialityView : ContentPage
	{
		public SpecialityView()
		{
			InitializeComponent();
            BindingContext = new SpecialityViewModel();
        }
	}
}