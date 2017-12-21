using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotherApp.Services.Interfaces
{
    public interface IClotherService
    {
        void CreateClother(Clother clother);
        IEnumerable<Clother> GetAllClother();
        Clother GetClotherById(int id);
        void UpdateClother(Clother clother);

        void CreateClotherType(ClotherType clotherType);
        IEnumerable<ClotherType> GetAllClotherTypes();

        void CreateBrand(Brand brand);
        IEnumerable<Brand> GetAllBrands();

        void CreatePictureForClother(int clotherId, System.Web.HttpPostedFileBase uploadImage);
    }
}
