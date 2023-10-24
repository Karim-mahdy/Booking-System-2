using Booking.Application.Services.Implementation;
using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using Booking.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Booking.Web.Area.Admin
{
    public class VillaRoomController : Controller
    {
        private readonly IVillaRoomService villaRoomService;
        private readonly IVillaService villaService;

        public VillaRoomController(IVillaRoomService villaRoomService, IVillaService villaService)
        {
            this.villaRoomService = villaRoomService;
            this.villaService = villaService;
        }


        public IActionResult Index()
        {
            return View(villaRoomService.GetVillaRooms());
        }

        public IActionResult Create()
        {
            var model = new VillaRoomViewModel();
            model.VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Create))]
        public IActionResult Create(VillaRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!villaRoomService.CheckVillaRoomExists(model.VillaRoom, null, null, null))
                {
                    villaRoomService.CreateVillaRoom(model.VillaRoom);
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
            var villaRoom = villaRoomService.GetVillaRoomById(Id);
            var model = new VillaRoomViewModel
            {
                VillaList = villaService.GetAllVillas().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),

                VillaRoom = villaRoom

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(VillaRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                if (villaRoomService.GetVillaRooms().Any(
                      x => x.VillaId == model.VillaRoom.VillaId
                      && x.RoomNumber == model.VillaRoom.RoomNumber
                      && x.Id != model.VillaRoom.Id))
                {
                    TempData["error"] = "The villa Number already exists.";
                    return RedirectToAction(nameof(Index));
                }
                
                villaRoomService.UpdateVillaRoom(model.VillaRoom);
                TempData["success"] = "The villa Number has been updated successfully.";
                return RedirectToAction(nameof(Index));

            }

            model.VillaList = villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(model);
        }

        public IActionResult Delete(int Id)
        {

            villaRoomService.DeleteVillaRoom(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IsRoomNumberUnique(int RoomNumber, int Id, int VillaId)
        {
            bool isUnique = villaRoomService.CheckVillaRoomExists(null, RoomNumber, Id, VillaId);
            return Json(isUnique);
        }
    }
}
