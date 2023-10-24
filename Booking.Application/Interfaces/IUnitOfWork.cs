using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IUnitOfWork
    {
        
        IVillaRepository VillaRepository { get; }
        IVillaRoomRepository VillaRoomRepository { get; }
        IApplicationUserRepository User { get; }
        IAmenityRepository AmenityRepository { get; }
        int Save();
    }
}
