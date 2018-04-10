namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model;
    using Model.Request;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    public class NewDoctorViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        private string age;
        private List<SpecialityResponse> speciality;
        public SpecialityResponse specialityResponse;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }
        public List<SpecialityResponse> Speciality
        {
            get => speciality;
            set => SetProperty(ref speciality, value);
        }
        public SpecialityResponse SelectPicker
        {
            get => specialityResponse;
            set => SetProperty(ref specialityResponse, value);
        }
        #endregion

        #region Constructor
        public NewDoctorViewModel()
        {
            LoadPicker();
        }
        #endregion

        #region Command
        public ICommand SaveNewDoctorCommand => new RelayCommand(SaveNewDoctor);

        private async void SaveNewDoctor()
        {
            if (String.IsNullOrEmpty(Name))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes introduccir un nombre");
                return;
            }
            if (String.IsNullOrEmpty(Age))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes introduccir una edad");
                return;
            }
            if (SelectPicker?.SpecialityId == null)
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes seleccionar una especialidad");
                return;
            }

            var doctor = new DoctorRequest()
            {
                Name = Name,
                Age = int.Parse(Age),
                SpecialityId = SelectPicker.SpecialityId
            };

            if (!await MainViewModel.GetInstance().ApiService.NewDoctor(doctor))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se ha podido añadir un nuevo doctor/a. Intentelo más tarde");
                return;
            }
            await MainViewModel.GetInstance().Navigation.BackOnDetailView();
        }
        #endregion

        #region Methods
        private async void LoadPicker()
        {
            if (!await MainViewModel.GetInstance().ApiService.IsConnection()) return;

            var listSpecialities = await MainViewModel.GetInstance().ApiService.GetSpecialities();

            if (listSpecialities != null)
            {
                Speciality = new List<SpecialityResponse>(listSpecialities);
            }
            else
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se puede obtener la lista de doctores");
            }
        }
        #endregion
    }
}
