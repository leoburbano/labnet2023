using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada():base ("¡Tu nombre no es Leandro!")  { 
        
        }
    }
}
