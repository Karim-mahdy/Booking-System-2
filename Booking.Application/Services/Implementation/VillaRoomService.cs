using Booking.Application.Interfaces;
using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Implementation
{
    public class VillaRoomService : IVillaRoomService
    {
        private readonly IUnitOfWork unitOfWork;

        public VillaRoomService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public bool CheckVillaRoomExists(VillaRoom? villaRoom, int? RoomNumber, int? Id, int? VillaId)
        {
            if (villaRoom != null)
            {
                return unitOfWork.VillaRoomRepository.Any(x => x.VillaId == villaRoom.VillaId && x.RoomNumber == villaRoom.RoomNumber);
            }
            else
            {
                return unitOfWork.VillaRoomRepository.Any(vr => vr.VillaId == VillaId && vr.RoomNumber == RoomNumber && vr.Id != Id);
            }
        }

        public VillaRoom GetVillaRoomById(int Id)
        {
            return unitOfWork.VillaRoomRepository.Get(x => x.Id == Id, includeProperties: "Villa");
        }

        public IEnumerable<VillaRoom> GetVillaRooms()
        {
            return unitOfWork.VillaRoomRepository.GetAll(includeProperties: "Villa");
        }
        public void CreateVillaRoom(VillaRoom villaRoom)
        {
            unitOfWork.VillaRoomRepository.Add(villaRoom);
            unitOfWork.Save();
        }


        public bool DeleteVillaRoom(int Id)
        {
            try
            {
                var villaRoom = unitOfWork.VillaRoomRepository.Get(x => x.Id == Id);
                if (villaRoom != null)
                {
                    unitOfWork.VillaRoomRepository.Remove(villaRoom);
                    unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public void UpdateVillaRoom(VillaRoom villaRoom)
        {

            unitOfWork.VillaRoomRepository.Update(villaRoom);

            unitOfWork.Save();
        }

    }
}
