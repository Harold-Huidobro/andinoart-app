namespace Andinoart_app.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;
    using Common.Models;

    public class AddArtisanViewModel : BaseViewModel
    {
        #region Atributtes
        private bool isRunning;
        private bool isEnabled;
        private ApiService apiService;

        #endregion

        #region Properties
        public string Dni{ get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string ArtesanalLine { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string History { get; set; }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        #endregion

        #region Constructors
        public AddArtisanViewModel()
        {
            this.IsEnabled = true;
            this.apiService = new ApiService();
        }
        #endregion

        #region Methods
        private async void Save()
        {
            if(string.IsNullOrEmpty(this.Dni))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Dni Error", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.FirstName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "FirstName Error", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.LastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "LastName Error", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.SecondLastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "SecondLastName Error", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.ArtesanalLine))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ArtesanalLine Error", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Address))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Address Error", "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var artisan = new Artisan
            {
                Address = this.Address,
                ArtesanalLine = this.ArtesanalLine,
                Cellphone = this.Cellphone,
                DNI=this.Dni,
                Email= this.Email,
                FirstName = this.FirstName,
                LastName= this.LastName,
                SecondLastName = this.SecondLastName,
                History = this.History,                
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlArtisansController"].ToString();
            var response = await this.apiService.Post(url, prefix, controller, artisan);
            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            await Application.Current.MainPage.Navigation.PopAsync();

        }
        #endregion

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }            
        }
        #endregion
    }
}
