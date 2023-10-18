using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interface
{
    public interface IVillaService
    {
        IEnumerable<Villa>GetAllVillas();
        Villa GetVillaById(int id);
        void Create(Villa villa);
        void Update(Villa villa);
        bool Delete(Villa villa);
       

    }
}
