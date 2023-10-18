using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
           
        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<VillaNumber> VillaNumbers { get; set; }
    }
}
