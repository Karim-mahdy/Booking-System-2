using Booking.Application.Interfaces;
using Booking.Application.Services.Interface;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Implementation
{
    public class VillaNumberService : IVillaNumberService
    {
        private readonly IUnitOfWork unitOfWork;

        public VillaNumberService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public bool CheckVillaNumberExists(int villa_Number)
        {
          return  unitOfWork.VillaNumberRepository.Any(x=>x.Villa_Number == villa_Number);
        }

        public VillaNumber GetVillaNumberById(int Id)
        {
            return unitOfWork.VillaNumberRepository.Get(x => x.Villa_Number == Id, includeProperties: "Villa");
        }

        public IEnumerable<VillaNumber> GetVillaNumbers()
        {
            return unitOfWork.VillaNumberRepository.GetAll(includeProperties: "Villa");
        }
        public void CreateVillaNumber(VillaNumber villaNumber)
        {
          unitOfWork.VillaNumberRepository.Add(villaNumber);
            unitOfWork.Save();
        }

        //public bool IfVillaNumberExistAndGreaterThan2(int villanumber)
        //{
        //    if(unitOfWork.VillaNumberRepository.GetAll(x => x.Villa_Number == villanumber).Count() > 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public bool DeleteVillaNumber(int Id)
        {
            try
            {
                var villaNumber = unitOfWork.VillaNumberRepository.Get(x => x.Villa_Number == Id);
                if (villaNumber != null)
                {
                    unitOfWork.VillaNumberRepository.Remove(villaNumber);
                    unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

      

        public void UpdateVillaNumber( VillaNumber villaNumber)
        {

            unitOfWork.VillaNumberRepository.Update(villaNumber); 
            unitOfWork.Save();
        }
    }
}
