namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class DoctorViewModel : BaseViewModel
    {
        #region Attributes 
        private ObservableCollection<DoctorResponse> doctorList;
        #endregion

        #region Properties
        public ObservableCollection<DoctorResponse> DoctorList
        {
            get => doctorList;
            set => SetProperty(ref doctorList, value);
        }
        #endregion

        #region Constructor
        public DoctorViewModel()
        {
            Load();
        }
        #endregion

        #region Command
        public ICommand NewDoctorCommand => new RelayCommand(NewDoctor);
        private async void NewDoctor()
        {
            await MainViewModel.GetInstance().Navigation.NavigateOnDetailView("NewDoctorView");
        }
        #endregion

        #region Methods
        private async void Load()
        {
            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listDoctors = await MainViewModel.GetInstance().ApiService.GetDoctor();

            if (listDoctors != null)
            {
                DoctorList = new ObservableCollection<DoctorResponse>(listDoctors);
            }
            else
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se puede obtener la lista de doctores");
            }
        }
        #endregion
    }
}
