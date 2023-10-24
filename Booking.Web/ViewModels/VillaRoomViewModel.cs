using Booking.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Booking.Web.ViewModels
{
    public class VillaRoomViewModel
    {

        public VillaRoom? VillaRoom { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
