using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Area.Admin
{
    public class VillaController : Controller
    {
        private readonly IVillaService villaService;

        public VillaController( IVillaService villaService )
        {
            this.villaService = villaService;
        }
        public IActionResult Index()
        { 
            return View(villaService.GetAllVillas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(Villa villa)
        {
            if (ModelState.IsValid) 
            {
                villaService.Create(villa);
            }
            return RedirectToAction(nameof(Create));
        }

        public IActionResult Edit(int Id)
        {
            var model = villaService.GetVillaById(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Edit))]
        public IActionResult EditPost(Villa villa)
        {
          if (ModelState.IsValid)
            {
                villaService.Update(villa);
            }
          return RedirectToAction(nameof(Edit));
        }

        
        public IActionResult Delete(int Id)
        {  
           var deletedOrNot = villaService.Delete(villaService.GetVillaById(Id));
           if (deletedOrNot = true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return View(nameof(Edit));
            }
        }
    }
}
