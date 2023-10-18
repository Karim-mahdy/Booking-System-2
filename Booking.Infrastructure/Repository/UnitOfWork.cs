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
        public IVillaNumberRepository VillaNumberRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            VillaRepository = new VillaRepository(context);
            VillaNumberRepository = new VillaNumberRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
