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
    public class AmenityService : IAmenityService
    {
        private readonly IUnitOfWork unitOfWork;

        public AmenityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Amenity> GetAllAmenities()
        {
            return unitOfWork.AmenityRepository.GetAll(includeProperties: "Villa");
        }

        public Amenity GetAmenityById(int id)
        {
            return unitOfWork.AmenityRepository.Get(x=>x.Id == id, includeProperties: "Villa");
        }

        public void CreateAmenity(Amenity amenity)
        {
            unitOfWork.AmenityRepository.Add(amenity);
            unitOfWork.Save();
        }

        public void UpdateAmenity(Amenity amenity)
        {
            unitOfWork.AmenityRepository.Update(amenity);
            unitOfWork.Save();
        }
        public bool DeleteAmenity(int id)
        {
            var amenity = unitOfWork.AmenityRepository.Get(x=>x.Id == id);
            if (amenity != null)
            {
                unitOfWork.AmenityRepository.Remove(amenity);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool CheckAmenityExistingperVilla(Amenity amenity)
        {
           return unitOfWork.AmenityRepository.Any(x=>x.Name == amenity.Name && amenity.VillaId == x.VillaId);
        }
    }
}
