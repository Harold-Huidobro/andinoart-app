namespace Andinoart_app.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Views;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class ArtisansViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<ArtisanItemViewModel> artisans;
        private bool isRefreshing;
        private bool isEnabled;
        private string filter;
        private List<Artisan> artisansList;
        #endregion

        #region Properties
        public ObservableCollection<ArtisanItemViewModel> Artisans
        {
            get { return artisans; }
            set { SetValue(ref artisans, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }

        public string Filter
        {
            get { return filter; }
            set
            {
                SetValue(ref filter, value);
                this.Search();
            }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Constructors
        public ArtisansViewModel()
        {
            this.apiService = new ApiService();
            this.LoadArtisans();
        }

        #endregion

        #region Methods
        private async void LoadArtisans()
        {
            this.IsRefreshing = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                //await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlArtisansController"].ToString();
            var response = await this.apiService.GetList<Artisan>(url,prefix,controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            this.artisansList = (List<Artisan>)response.Result;
            this.Artisans = new ObservableCollection<ArtisanItemViewModel>(this.ToArtisanItemViewModel());
            this.IsRefreshing = false;
            this.IsEnabled = true;

        }

        private IEnumerable<ArtisanItemViewModel> ToArtisanItemViewModel()
        {
            return this.artisansList.Select(a => new ArtisanItemViewModel
            {
                DNI = a.DNI,
                FirstName = a.FirstName,
                LastName = a.LastName,
                SecondLastName = a.SecondLastName,
                ArtesanalLine = a.ArtesanalLine,
                Email = a.Email,
                Cellphone = a.Cellphone,
                Address = a.Address,
                History = a.History,
                IsActive = a.IsActive,
                CreatedOn = a.CreatedOn,
            });
        }

        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.Artisans = new ObservableCollection<ArtisanItemViewModel>(this.ToArtisanItemViewModel());
            }
            else
            {
                this.Artisans = new ObservableCollection<ArtisanItemViewModel>(
                    this.ToArtisanItemViewModel().Where(a=> a.FirstName.ToLower().Contains(this.Filter.ToLower()) ||
                                            a.LastName.ToLower().Contains(this.Filter.ToLower()) ||
                                            a.SecondLastName.ToLower().Contains(this.Filter.ToLower()) ||
                                            a.DNI.ToLower().Contains(this.Filter.ToLower()) ));

            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadArtisans);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        #endregion
    }
}
