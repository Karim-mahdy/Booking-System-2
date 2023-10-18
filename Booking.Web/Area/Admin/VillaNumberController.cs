using Booking.Application.Services.Implementation;
using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using Booking.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking.Web.Area.Admin
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService villaNumberService;
        private readonly IVillaService villaService;

        public VillaNumberController (IVillaNumberService villaNumberService , IVillaService villaService)
        {
            this.villaNumberService = villaNumberService;
            this.villaService = villaService;
        }


        public IActionResult Index()
        {            
            return View(villaNumberService.GetVillaNumbers());
        }

        public IActionResult Create ()
        {
            var model = new VillaNumberViewModel();
            model.VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
            {
                Value =x.Id.ToString(),
                Text = x.Name
            });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Create))]
        public IActionResult Create(VillaNumberViewModel model)
        {
            if (ModelState.IsValid && model != null && model.VillaNumber != null)
            {
                if (!villaNumberService.CheckVillaNumberExists(model.VillaNumber.Villa_Number))
                {
                    villaNumberService.CreateVillaNumber(model.VillaNumber);
                    TempData["success"] = "The villa Number has been created successfully.";
                }
                else
                {
                    
                    TempData["error"] = "The villa Number already exists.";
                    model.VillaList = villaService.GetAllVillas().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var villaNumber = villaNumberService.GetVillaNumberById(Id);
            var model = new VillaNumberViewModel
            {
                VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                VillaNumber = villaNumber

            };
            return View(model);
        }

        [HttpPost]       
        public IActionResult Edit(VillaNumberViewModel model)
        {
            if (ModelState.IsValid && model != null && model.VillaNumber != null)
            {
                if (!villaNumberService.CheckVillaNumberExists(model.VillaNumber.Villa_Number))
                {
                    //if (villaNumberService.IfVillaNumberExistAndGreaterThan2(model.VillaNumber.Villa_Number))
                    //{
                        villaNumberService.UpdateVillaNumber(model.VillaNumber);
                        TempData["success"] = "The villa Number has been updated successfully.";
                    //}
                  
                }
                else
                {

                    TempData["error"] = "The villa Number already exists.";
                    model.VillaList = villaService.GetAllVillas().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            
            villaNumberService.DeleteVillaNumber(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
