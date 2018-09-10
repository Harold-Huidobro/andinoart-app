namespace Andinoart_app.ViewModels
{
    using System.Windows.Input;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;

    public class ArtisanItemViewModel:Artisan
    {
        #region Commands
        public ICommand SelectArtisanCommand
        {
            get
            {
                return new RelayCommand(SelectArtisan);
            }

        }
        #endregion

        #region Methods
        private async void SelectArtisan()
        {
            MainViewModel.GetInstance().Artisan = new ArtisanViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ArtisanTabbedPage());
        } 
        #endregion
    }
}
