namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Model.Request;
    using System;
    using System.Windows.Input;

    public class AddSpecialityViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        #endregion

        #region Constructor
        public AddSpecialityViewModel()
        {
            Title = "Añadir especialidad";
        }
        #endregion

        #region Command
        public ICommand NewSpecialityCommand => new RelayCommand(NewSpeciality);

        private async void NewSpeciality()
        {
            if (String.IsNullOrEmpty(Name))
            {
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Debes introduccir una especialidad");
                return;
            }

            var speciality = new SpecialityRequest()
            {
                Name = Name
            };

            var result = await MainViewModel.GetInstance().ApiService.NewSpeciality(speciality);

            if (!result.Contains("Ok"))
            {
                if (result.Contains("The records exist"))
                {
                    await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "Ya existe esa especialidad");  return;
                }
                await MainViewModel.GetInstance().DialogService.ShowMessage("Error", "No se ha podido añadir un nuevo doctor/a. Intentelo más tarde"); return;
            }

            await MainViewModel.GetInstance().Navigation.BackOnDetailView();
        }
        #endregion
    }
}
