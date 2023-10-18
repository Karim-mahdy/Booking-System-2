using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interface
{
    public interface IVillaNumberService
    {
        IEnumerable<VillaNumber> GetVillaNumbers();

        VillaNumber GetVillaNumberById(int Id);

        void CreateVillaNumber(VillaNumber villaNumber);

        void UpdateVillaNumber(VillaNumber villaNumber);

        bool DeleteVillaNumber(int Id);

        bool CheckVillaNumberExists(int villa_Number);

        //bool IfVillaNumberExistAndGreaterThan2(int villa_Number);
    }
}
