using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class ShipperLogic : BaseLogic, IABMLogic<Shippers>
    {
       public IEnumerable<Shippers> GetAll() 
        {
            return _northwindContext.Shippers;
        }  

        public void Add(Shippers newShipper)
        {
            _northwindContext.Shippers.Add(newShipper);
            _northwindContext.SaveChanges();
            Console.WriteLine("Shipper Agregado!");
        }

        public void Delete(int id) 
        {
            var shipperEliminar = _northwindContext.Shippers.Find(id);
            _northwindContext.Shippers.Remove(shipperEliminar);
            _northwindContext.SaveChanges();
            Console.WriteLine("Shipper Eliminado!");
        }

        public void Update(Shippers shipper)
        {
            var shipperUpdate = _northwindContext.Shippers.Find(shipper.ShipperID);
            shipperUpdate.CompanyName = shipper.CompanyName;
            _northwindContext.SaveChanges();
            Console.WriteLine("Shipper Actualizado!");
        }
    }
}
