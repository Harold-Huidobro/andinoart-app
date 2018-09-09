namespace Andinoart_app.ViewModels
{
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
    }
}
