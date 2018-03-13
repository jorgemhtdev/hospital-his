namespace HospitalApp.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : MasterDetailPage
    {
		public MasterView ()
		{
			InitializeComponent ();
	        App.Master = this;
	        App.Navigator = Navigator;
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        App.Master = this;
	        App.Navigator = Navigator;
	    }
    }
}