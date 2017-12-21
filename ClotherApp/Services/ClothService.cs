using ClothApp.Data.Repositories;
using ClothApp.Domain;
using ClothApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothApp.Services
{
    public class ClothService : IClothService
    {
        private readonly ClothRepository _clothRepository = new ClothRepository();
        private readonly ClothTypeRepository _clothTypeRepository = new ClothTypeRepository();
        private readonly BrandRepository _brandRepository = new BrandRepository();
        private readonly PictureRepository _pictureRepository = new PictureRepository();

        public void CreateCloth(Cloth cloth)
        {
            _clothRepository.Create(cloth);
        }

        public IEnumerable<Cloth> GetAllClothes()
        {
            return _clothRepository.GetAll();
        }

        public Cloth GetClothById(int id)
        {
            return _clothRepository.GetById(id);
        }

        public void UpdateCloth(Cloth cloth)
        {
            _clothRepository.Update(cloth);
        }

        public void CreateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        public void CreateClothType(ClothType clothType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClothType> GetAllClothTypes()
        {
            return _clothTypeRepository.GetAll();
        }

        public void CreatePictureForCloth(int clothId, HttpPostedFileBase uploadImage)
        {
            byte[] imgData = new byte[uploadImage.ContentLength];
            using (var inputStream = uploadImage.InputStream)
            {
                inputStream.Read(imgData, 0, uploadImage.ContentLength);
            }

            var picture = new Picture
            {
                ClothId = clothId,
                Image = imgData,
                Name = uploadImage.FileName
            };

            _pictureRepository.Create(picture);
        }
    }
}