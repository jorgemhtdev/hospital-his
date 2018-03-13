namespace HospitalApp.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : TabbedPage
    {
        public HomeView ()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Children.Add(new SpecialitieView() { Title = "Especialidades" }); // Icon = "ListWhite"
                    Children.Add(new DoctorView() { Title = "Doctores"}); // Icon = "Map" 
                    break;
                case Device.Android:
                    Children.Add(new SpecialitieView() { Title = "Especialidades" });
                    Children.Add(new DoctorView() { Title = "Doctores" });
                    break;
                default:
                    Children.Add(new SpecialitieView() { Title = "Especialidades" });
                    Children.Add(new DoctorView() { Title = "Doctores" });
                    break;
            }
        }
    }
}