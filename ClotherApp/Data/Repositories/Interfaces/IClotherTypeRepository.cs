using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotherApp.Data.Repositories.Interfaces
{
    public interface IClotherTypeRepository
    {
        void Create(ClotherType clotherType);
        IEnumerable<ClotherType> GetAll();
    }
}
