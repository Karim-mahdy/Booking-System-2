﻿using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IVillaRoomRepository : IRepository<VillaRoom> 
    {
        
        public void Update(VillaRoom entity);
         


    }
}
