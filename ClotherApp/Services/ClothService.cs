﻿using AutoMapper;
using ClothApp.Data.Repositories;
using ClothApp.Domain;
using ClothApp.Models;
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

        public IEnumerable<ClothIndexViewModel> GetAllClothes()
        {
            var clothes = _clothRepository.GetAll();

            return Mapper.Map<IEnumerable<Cloth>, List<ClothIndexViewModel>>(clothes);
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

        public List<Picture> GetPicturesList(HttpPostedFileBase[] uploadImages)
        {
            byte[] imgData;
            var pictureList = new List<Picture>();

            foreach (var img in uploadImages)
            {
                if (img != null)
                {
                    imgData = new byte[img.ContentLength];

                    using (var inputStream = img.InputStream)
                    {
                        inputStream.Read(imgData, 0, img.ContentLength);
                    }

                    var picture = new Picture
                    {
                        Image = imgData,
                        Name = img.FileName
                    };

                    pictureList.Add(picture);
                }
            }

            return pictureList;
        }

        public void CreatePicturesForCloth(int clothId, HttpPostedFileBase[] uploadImages)
        {
            byte[] imgData;

            foreach (var img in uploadImages)
            {
                if (img != null)
                {
                    imgData = new byte[img.ContentLength];

                    using (var inputStream = img.InputStream)
                    {
                        inputStream.Read(imgData, 0, img.ContentLength);
                    }

                    var picture = new Picture
                    {
                        ClothId = clothId,
                        Image = imgData,
                        Name = img.FileName
                    };

                    _pictureRepository.Create(picture);
                }
            }
        }
    }
}