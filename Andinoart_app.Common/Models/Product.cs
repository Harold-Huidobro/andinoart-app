
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
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishOn { get; set; }
    }
}
