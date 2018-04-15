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
        private bool isLoad;
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
        public bool IsLoad
        {
            get => isLoad;
            set => SetProperty(ref isLoad, value);
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
            IsLoad = false;
            Title = "Doctores";
            await MainViewModel.GetInstance().Navigation.NavigateOnDetailView("AddDoctorView");
        }
        #endregion

        #region Methods
        public async Task Load()
        {
            if (IsLoad) return;

            ActivityIndicatorOn();
           
            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listDoctors = await MainViewModel.GetInstance().ApiService.GetDoctor();

            if (listDoctors != null)
            {
                DoctorList = new ObservableCollection<DoctorResponse>(listDoctors);
                IsVisibleListView = true;
                IsLoad = true;
            }
            else
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se puede obtener la lista de doctores");
            }

            ActivityIndicatorOff();
        }
        #endregion
    }
}
