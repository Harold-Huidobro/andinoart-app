namespace Andinoart_app.ViewModels
{
    using Common.Models;

    public class ArtisanViewModel
    {
        #region Properties
        public Artisan Artisan
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public ArtisanViewModel(Artisan artisan)
        {
            this.Artisan = artisan;
        } 
        #endregion
    }
}