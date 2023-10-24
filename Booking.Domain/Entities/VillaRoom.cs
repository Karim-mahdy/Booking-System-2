using Booking.Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
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
    public class VillaRoom
    {
        
        [Key]
        public int Id { get; set; }


        [Display(Name = "Room Number")]
        [Range(1,1000,ErrorMessage ="Room Number must be between 1 - 1000")]
        
        public required int RoomNumber { get; set; }

        [StringLength(150, ErrorMessage = "Special Details must be within 100 characters.")]

        public string? SpecialDetails { get; set; }


        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        [ValidateNever]
        public Villa Villa { get; set; }

    }
}
