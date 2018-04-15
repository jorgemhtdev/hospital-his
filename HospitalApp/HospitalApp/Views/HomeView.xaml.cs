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
                    Children.Add(new SpecialityView() { Title = "Especialidades", Icon = "Specialities"});
                    Children.Add(new DoctorView() { Title = "Doctores", Icon = "UserTab" });
                    break;
                case Device.Android:
                    Children.Add(new SpecialityView() { Title = "Especialidades" });
                    Children.Add(new DoctorView() { Title = "Doctores" });
                    break;
                default:
                    Children.Add(new SpecialityView() { Title = "Especialidades" });
                    Children.Add(new DoctorView() { Title = "Doctores" });
                    break;
            }
        }
    }
}