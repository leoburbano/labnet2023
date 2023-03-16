using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    interface IABMLogic<T>
    {
        IEnumerable<T> GetAll();

        void Add(T newShipper);

        void Delete(int id);
        void Update(T shipper);
    }
}
