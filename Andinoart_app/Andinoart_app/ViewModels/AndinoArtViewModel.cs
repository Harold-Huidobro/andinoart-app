namespace Andinoart_app.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;

    public class AndinoArtViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        //private ObservableCollection<Artisan> artisans;
        #endregion

        #region Properties
        //public ObservableCollection<Artisan> Artisans
        //{
        //    get { return artisans; }
        //    set { SetValue(ref artisans, value); }
        //}
        #endregion

        #region Constructors
        public AndinoArtViewModel()
        {
            this.apiService = new ApiService();
            //this.LoadArtisans();
        }

        #endregion

        #region Methods
        private /*async*/ void LoadArtisans()
        {
            //var response = await this.apiService.GetList<Artisan>("uri_my_api_artisans","serviceprefix","controller");
            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", response.message, "Accept");
            //    return;
            //}

            //var list = (List<Artisan>)response.Result;
            //this.Artisans = new ObservableCollection<Artisan>(list);

        }
        #endregion
    }
}
