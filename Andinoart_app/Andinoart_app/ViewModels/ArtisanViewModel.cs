namespace Andinoart_app.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;

    public class ArtisanViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Artisan> artisans;
        private bool isRefreshing;
        private string filter;
        private List<Artisan> artisansList;
        #endregion

        #region Properties
        public ObservableCollection<Artisan> Artisans
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
        #endregion

        #region Constructors
        public ArtisanViewModel()
        {
            this.apiService = new ApiService();
            this.LoadArtisans();
        }

        #endregion

        #region Methods
        private async void LoadArtisans()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Artisan>("https://andinoartappapi.azurewebsites.net", "/api", "/Artisans");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            this.artisansList = (List<Artisan>)response.Result;
            this.Artisans = new ObservableCollection<Artisan>(artisansList);
            this.IsRefreshing = false;

        }

        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.Artisans = new ObservableCollection<Artisan>(artisansList);
            }
            else
            {
                this.Artisans = new ObservableCollection<Artisan>(
                    artisansList.Where(a=> a.FirstName.ToLower().Contains(this.Filter.ToLower()) ||
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
