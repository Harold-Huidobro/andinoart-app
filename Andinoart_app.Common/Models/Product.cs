
namespace Andinoart_app.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Precio Compra")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Precio Venta")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SalePrice { get; set; }

        [Display(Name = "Longitud")]
        public decimal Length { get; set; }

        [Display(Name = "Ancho")]
        public decimal Width { get; set; }

        [Display(Name = "Altura")]
        public decimal Height { get; set; }

        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Calidad")]
        public string Quality { get; set; }

        /*public string Type { get; set; }*/

        [Required]
        [Display(Name = "Material")]
        public string Material { get; set; }

        /*public int Proveedor{ get; set;}*/

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observation { get; set; }

        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "noproduct";
                }
                return $"https://andinoartappapi.azurewebsites.net/{this.ImagePath.Substring(1)}";
            }
        }

        [Required]
        [Display(Name = "Publicado en")]
        [DataType(DataType.Date)]
        public DateTime PublishOn { get; set; }

        [Display(Name = "Disponible")]
        public bool IsAvailable { get; set; }

    }
}
