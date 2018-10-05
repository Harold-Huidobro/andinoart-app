
namespace Andinoart_app.Backend.Models
{
    using System.Web;
    using Andinoart_app.Common.Models;

    public class ProductView : Product
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}