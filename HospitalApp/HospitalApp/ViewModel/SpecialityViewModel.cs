namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class SpecialityViewModel : BaseViewModel
    {
        #region Attributes 
        private ObservableCollection<SpecialityResponse> specialitiesList;
        #endregion

        #region Properties
        public ObservableCollection<SpecialityResponse> SpecialitiesList
        {
            get => specialitiesList;
            set => SetProperty(ref specialitiesList, value);
        }
        #endregion

        #region Constructor
        public SpecialityViewModel()
        {
            Load();
        }
        #endregion

        #region Command
        public ICommand NewSpecialityCommand => new RelayCommand(NewSpeciality);
        private async void NewSpeciality()
        {
            await MainViewModel.GetInstance().Navigation.NavigateOnDetailView("NewSpecialityView");
        }
        #endregion

        #region Methods
        private async void Load()
        {
            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listSpecialities = await MainViewModel.GetInstance().ApiService.GetSpecialities();

            if (listSpecialities != null)
            {
                SpecialitiesList = new ObservableCollection<SpecialityResponse>(listSpecialities);
            }
            else
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se puede obtener la lista de doctores");
            }
        }
        #endregion
    }
}
