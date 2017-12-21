using ClotherApp.Data.Repositories;
using ClotherApp.Domain;
using ClotherApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherApp.Services
{
    public class ClotherService : IClotherService
    {
        private readonly ClotherRepository _clotherRepository = new ClotherRepository();
        private readonly ClotherTypeRepository _clotherTypeRepository = new ClotherTypeRepository();
        private readonly BrandRepository _brandRepository = new BrandRepository();
        private readonly PictureRepository _pictureRepository = new PictureRepository();

        public void CreateClother(Clother clother)
        {
            _clotherRepository.Create(clother);
        }

        public IEnumerable<Clother> GetAllClother()
        {
            return _clotherRepository.GetAll();
        }

        public Clother GetClotherById(int id)
        {
            return _clotherRepository.GetById(id);
        }

        public void UpdateClother(Clother clother)
        {
            _clotherRepository.Update(clother);
        }

        public void CreateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        public void CreateClotherType(ClotherType clotherType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClotherType> GetAllClotherTypes()
        {
            return _clotherTypeRepository.GetAll();
        }

        public void CreatePictureForClother(int clotherId, HttpPostedFileBase uploadImage)
        {
            byte[] imgData = new byte[uploadImage.ContentLength];
            using (var inputStream = uploadImage.InputStream)
            {
                inputStream.Read(imgData, 0, uploadImage.ContentLength);
            }

            var picture = new Picture
            {
                ClotherId = clotherId,
                Image = imgData,
                Name = uploadImage.FileName
            };

            _pictureRepository.Create(picture);
        }
    }
}