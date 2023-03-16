using Practica3.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext _northwindContext;

        public BaseLogic() {
            _northwindContext = new NorthwindContext();
        }

    }
}
