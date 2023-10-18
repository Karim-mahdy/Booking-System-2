using Booking.Application.Interfaces;
using Booking.Application.Services.Interface;
using Booking.Application.Settings;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Implementation
{
    public class VillaService : IVillaService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        string imagePath;
        public VillaService(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this.UnitOfWork = UnitOfWork;
            this.webHostEnvironment = webHostEnvironment;
            imagePath = $"{webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public IEnumerable<Villa> GetAllVillas()
        {
            return UnitOfWork.VillaRepository.GetAll();
        }

        public Villa GetVillaById(int Id)
        {
            return UnitOfWork.VillaRepository.Get(x => x.Id == Id);
        }
        public void Create(Villa villa)
        {
            try
            {
                if (villa != null)
                {
                    villa.ImageUrl = SaveImage(villa.Image);
                }

                UnitOfWork.VillaRepository.Add(villa);
                UnitOfWork.Save();
            }
            catch (Exception)
            {
                var path = Path.Combine(imagePath, villa.ImageUrl);
                File.Delete(path);

            }
        }

        public bool Delete(Villa villa)
        {
            try
            {
                UnitOfWork.VillaRepository.Remove(villa);
                UnitOfWork.Save();
                if (villa.ImageUrl != null)
                {
                    var path = Path.Combine(imagePath, villa.ImageUrl);
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(@"\Exception\Errors.txt",ex.Message); 
            }
            return true;     
        }

        public void Update(Villa villa)
        {
            string oldimg = villa.ImageUrl;
            string newimg = string.Empty;
            int affectedRow = 0;
            try
            {
                if (villa.Image != null)
                {
                    newimg = SaveImage(villa.Image);
                    villa.ImageUrl = newimg;
                    UnitOfWork.VillaRepository.Update(villa);
                    affectedRow = UnitOfWork.Save();
                    if (affectedRow > 0)
                    {
                        var oldpic = Path.Combine(imagePath, oldimg);
                        File.Delete(oldpic);
                    }
                    else
                    {
                        var newpic = Path.Combine(imagePath, villa.ImageUrl);
                        File.Delete(newpic);
                    }
                }

            }
            catch (Exception)
            {
                var newpic = Path.Combine(imagePath, villa.ImageUrl);
                File.Delete(newpic);

            }


        }

        string SaveImage(IFormFile Image)
        {
            if (Image != null)
            {
                var ImageName = $"{Guid.NewGuid()}{Path.GetExtension(Image.FileName)}";
                var path = Path.Combine(imagePath, ImageName);

                using (var stream = File.Create(path))
                {
                    Image.CopyTo(stream);
                }

                return ImageName;
            }

            return null;
        }
    }
}
