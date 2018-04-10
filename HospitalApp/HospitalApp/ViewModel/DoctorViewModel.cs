namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class DoctorViewModel : BaseViewModel
    {
        #region Attributes 
        private ObservableCollection<DoctorResponse> doctorList;
        private bool isVisibleListView;
        #endregion

        #region Properties
        public ObservableCollection<DoctorResponse> DoctorList
        {
            get => doctorList;
            set => SetProperty(ref doctorList, value);
        }
        public bool IsVisibleListView
        {
            get => isVisibleListView;
            set => SetProperty(ref isVisibleListView, value);
        }
        #endregion

        #region Constructor
        public DoctorViewModel()
        {
           
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
        public async Task Load()
        {
            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listDoctors = await MainViewModel.GetInstance().ApiService.GetDoctor();

            if (listDoctors != null)
            {
                DoctorList = new ObservableCollection<DoctorResponse>(listDoctors);
                IsVisibleListView = true;
            }
            else
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se puede obtener la lista de doctores");
            }
        }
        #endregion
    }
}
