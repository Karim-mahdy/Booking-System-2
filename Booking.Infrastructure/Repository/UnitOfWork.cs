using Booking.Application.Interfaces;
using Booking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IVillaRepository VillaRepository { get; private set; }
        public IVillaRoomRepository VillaRoomRepository { get; private set; }
        public IAmenityRepository AmenityRepository { get; private set; }
        public IApplicationUserRepository User { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            VillaRepository = new VillaRepository(context);
            VillaRoomRepository = new VillaRoomRepository(context);
            AmenityRepository = new AmenityRepository(context); 

        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
