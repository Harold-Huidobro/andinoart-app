namespace Andinoart_app.Common.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Models;

    public class ArtisanResponse
    {
        public int ArtisanId { get; set; }

        public string DNI { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string ArtesanalLine { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string History { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}