namespace Andinoart_app.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Artisan
    {
        [Key]
        public int ArtisanId { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SecondLastName { get; set; }

        public string Cellphone { get; set; }

        [Required]
        public string Address { get; set; }

        public string History { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

    }
}
