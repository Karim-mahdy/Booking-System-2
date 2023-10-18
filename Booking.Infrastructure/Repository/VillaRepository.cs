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
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext context;

        public VillaRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Villa entity)
        {
          context.Villas.Update(entity);
        }
    }
}
