namespace HospitalApp.Views
{
    using HospitalApp.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorView : ContentPage
	{
		public DoctorView ()
		{
			InitializeComponent();
            BindingContext = new DoctorViewModel();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ((DoctorViewModel)BindingContext).Load();
        }
    }
}