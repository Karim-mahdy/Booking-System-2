using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Booking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext context;

        public VillaNumberRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(VillaNumber entity)
        {
           context.Update(entity);
        }
    }
}
