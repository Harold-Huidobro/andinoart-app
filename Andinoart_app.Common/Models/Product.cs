
namespace Andinoart_app.Common.Models
{
    using Newtonsoft.Json;
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
        public string Description { get; set; }

        /*[Required]
        [Display(Name = "Precio Compra")]
        public decimal PurchasePrice { get; set; }*/

        [Required]
        [Display(Name = "Precio Venta")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Longitud")]
        public decimal Length { get; set; }

        [Display(Name = "Anchura")]
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

        /*[Required]
        public byte[] Image { get; set; }*/

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publicado en")]
        public DateTime PublishOn { get; set; }

        [Display(Name = "Disponible")]
        public bool IsAvailable { get; set; }
       
        public int ArtisanId { get; set; }

        [JsonIgnore]
        public virtual Artisan Artisan { get; set; }
    }

}
