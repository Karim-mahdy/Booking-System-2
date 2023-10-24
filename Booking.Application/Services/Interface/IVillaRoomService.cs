using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interface
{
    public interface IVillaRoomService
    {
        IEnumerable<VillaRoom> GetVillaRooms();

        VillaRoom GetVillaRoomById(int Id);

        void CreateVillaRoom(VillaRoom villaRoom);

        void UpdateVillaRoom(VillaRoom villaRoom);

        bool DeleteVillaRoom(int Id);

        bool CheckVillaRoomExists(VillaRoom? villaRoom, int? RoomNumber, int? Id, int? VillaId);
       
        
    }
}
