namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class SpecialityViewModel : BaseViewModel
    {
        #region Attributes 
        private ObservableCollection<SpecialityResponse> specialitiesList;
        private bool isVisibleListView;
        private bool isLoad;
        #endregion

        #region Properties
        public ObservableCollection<SpecialityResponse> SpecialitiesList
        {
            get => specialitiesList;
            set => SetProperty(ref specialitiesList, value);
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
        public SpecialityViewModel()
        {
            
        }
        #endregion

        #region Command
        public ICommand NewSpecialityCommand => new RelayCommand(NewSpeciality);
        private async void NewSpeciality()
        {
            IsLoad = false;
            await MainViewModel.GetInstance().Navigation.NavigateOnDetailView("NewSpecialityView");
        }
        #endregion

        #region Methods
        public async Task Load()
        {
            if (IsLoad) return;

            ActivityIndicatorOn();

            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listSpecialities = await MainViewModel.GetInstance().ApiService.GetSpecialities();

            if (listSpecialities != null)
            {
                SpecialitiesList = new ObservableCollection<SpecialityResponse>(listSpecialities);
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
