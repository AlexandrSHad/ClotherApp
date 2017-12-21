using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothApp.Services.Interfaces
{
    public interface IClothService
    {
        void CreateCloth(Cloth cloth);
        IEnumerable<Cloth> GetAllClothes();
        Cloth GetClothById(int id);
        void UpdateCloth(Cloth cloth);

        void CreateClothType(ClothType clothType);
        IEnumerable<ClothType> GetAllClothTypes();

        void CreateBrand(Brand brand);
        IEnumerable<Brand> GetAllBrands();

        void CreatePictureForCloth(int clothId, System.Web.HttpPostedFileBase uploadImage);
    }
}
