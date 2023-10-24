using Booking.Application.Interfaces;
using Booking.Application.Services.Implementation;
using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using Booking.Infrastructure.Repository;
using Booking.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking.Web.Area.Admin
{
    public class AmenityController : Controller
    {
     
        private readonly IAmenityService amenityService;

        private readonly IVillaService villaService;

        public AmenityController(IAmenityService amenityService, IVillaService villaService)
        {
           
            this.amenityService = amenityService;
            this.villaService = villaService;
        }
        public IActionResult Index()
        {
            var amenities = amenityService.GetAllAmenities();
            return View(amenities);
        }

        
        public IActionResult Create()
        {
            var model = new AmenityVillaViewModel()
            {
                VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                   
                })
            };           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AmenityVillaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!amenityService.CheckAmenityExistingperVilla(model.Amenity))
                {
                    amenityService.CreateAmenity(model.Amenity);
                    TempData["success"] = "The amenity has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }

            }
            model.VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            TempData["error"] = "The Amenity already exists.";
            return View(model);
        }

        public IActionResult Edit(int Id)
        {

            var model = new AmenityVillaViewModel
            {
                Amenity = amenityService.GetAmenityById(Id),
                VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AmenityVillaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (amenityService.GetAllAmenities().Any(
                    x => x.Name == model.Amenity.Name
                    && x.VillaId == model.Amenity.VillaId
                    && x.Id != model.Amenity.Id)
                    )
                {
                    TempData["error"] = "The Amenity already exists.";
                    return RedirectToAction(nameof(Index));
                }
                amenityService.UpdateAmenity(model.Amenity);
                TempData["success"] = "The Amenity has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            model.VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            var amenity = amenityService.DeleteAmenity(Id);
            if(amenity == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
