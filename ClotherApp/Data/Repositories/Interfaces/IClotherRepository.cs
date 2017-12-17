using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotherApp.Data.Repositories.Interfaces
{
    public interface IClotherRepository
    {
        void Create(Clother clother);
        IEnumerable<Clother> GetAll();
        Clother GetById(int id);
        void Update(Clother clother);
    }
}
