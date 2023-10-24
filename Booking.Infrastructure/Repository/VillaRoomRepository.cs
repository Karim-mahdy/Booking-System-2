using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Booking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository
{
    public class VillaRoomRepository : Repository<VillaRoom>, IVillaRoomRepository
    {
        private readonly ApplicationDbContext context;

        public VillaRoomRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        

        public void Update(VillaRoom entity)
        {
           context.Update(entity);
        }
         
    }
}
