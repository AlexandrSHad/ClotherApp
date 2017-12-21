using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothApp.Data.Repositories.Interfaces
{
    public interface IClothTypeRepository
    {
        void Create(ClothType clothType);
        IEnumerable<ClothType> GetAll();
    }
}
