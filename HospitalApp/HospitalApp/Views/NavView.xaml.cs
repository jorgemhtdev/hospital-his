namespace HospitalApp.Views
{
    using ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavView : ContentPage
	{
		public NavView ()
		{
		    InitializeComponent();
		    BindingContext = new NavViewModel();
		}
	}
}