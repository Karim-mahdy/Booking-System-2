using Booking.Domain.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Name must be geater than 3 char.")]
        public required string Name { get; set; }

        [MaxLength(500, ErrorMessage = "The Description must be within 500 characters.")]
        public string? Description { get; set; }


        [Display(Name = "Price per night")]
        [Range(10, 10000, ErrorMessage = "Price should be between $10 and $10,000.")]
        public double Price { get; set; }

        [Range(1, 500, ErrorMessage = "Sqft should be between 1 and 500.")]
        public int Sqft { get; set; }

        [Range(1, 10, ErrorMessage = "Occupancy should be between 1 and 10.")]
        public int Occupancy { get; set; }

        [NotMapped]
        [AllowedExtensions(FileSettings.AllowedExtensions),MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenity { get; set; }

        [NotMapped]
        public bool IsAvailable { get; set; } = true;

    }
}
