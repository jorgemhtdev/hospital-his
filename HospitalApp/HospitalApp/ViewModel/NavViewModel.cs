namespace HospitalApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class NavViewModel : BaseViewModel
    {
        #region Attributes 
        private ObservableCollection<NavModel> hamburgerNav;
        private NavModel selectedItem;
        #endregion

        #region Properties
        public ObservableCollection<NavModel> HamburgerNav
        {
            get => hamburgerNav;
            set => SetProperty(ref hamburgerNav, value);
        }
        public NavModel SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                HandleSelection();
            }
        }
        #endregion

        #region Methods
        public NavViewModel()
        {
            LoadNav();
        }

        private void LoadNav()
        {
            var navList = new List<NavModel>
            {
                new NavModel
                {
                    Icon = "#",
                    ViewName = "UserView",
                    Title = "Mi perfil"
                },
                new NavModel
                {
                    Icon = "#",
                    ViewName = "#",
                    Title = "Example002"
                },
                new NavModel
                {
                    Icon = "#",
                    ViewName = "#",
                    Title = "Example003"
                },
                new NavModel
                {
                    Icon = "#",
                    ViewName = "#",
                    Title = "Example004"
                }
            };

            HamburgerNav = new ObservableCollection<NavModel>(navList);
        }

        private async void HandleSelection()
        {
            if (SelectedItem?.ViewName == null) return;

            await MainViewModel.GetInstance().Navigation.NavigateOnMasterView(SelectedItem.ViewName);
        }
        #endregion

        #region Commands
        public ICommand LogoutCommand => new RelayCommand(Logout);

        private async void Logout()
        {
            await MainViewModel.GetInstance().Navigation.NavigateOnMasterView("LogoutAccount");
        }
        #endregion
    }

    public class NavModel
    {
        #region Properties
        public string Title { get; set; }
        public string ViewName { get; set; }
        public string Icon { get; set; }
        #endregion
    }
}

