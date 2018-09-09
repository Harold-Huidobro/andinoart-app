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
        [Display(Name ="Nombres")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string SecondLastName { get; set; }

        [Required]
        [Display(Name = "Linea Artesanal")]
        public string ArtesanalLine { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.MultilineText)]
        public string History { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

    }
}
