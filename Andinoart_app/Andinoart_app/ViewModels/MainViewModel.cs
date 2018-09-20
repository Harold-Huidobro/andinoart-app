namespace Andinoart_app.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;

    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public ArtisansViewModel Artisans
        {
            get;
            set;
        }

        public ProductsViewModel Products
        {
            get;
            set;
        }

        public ArtisanViewModel Artisan
        {
            get;
            set;
        }

        public AddArtisanViewModel AddArtisan
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance==null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        public ICommand AddArtisanCommand
        {
            get
            {
                return new RelayCommand(GoToAddArtisan);
            }
            
        }

        private async void GoToAddArtisan()
        {
            this.AddArtisan = new AddArtisanViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddArtisanPage());
        }
    }
}
