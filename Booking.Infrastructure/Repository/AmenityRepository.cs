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
    public class AmenityRepository : Repository<Amenity>, IAmentityRepository
    {
        private readonly ApplicationDbContext context;

        public AmenityRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Amenity amenity)
        {
            throw new NotImplementedException();
        }
    }
}
