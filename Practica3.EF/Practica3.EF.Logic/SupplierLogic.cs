using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class SupplierLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return _northwindContext.Suppliers.ToList();
        }
        
        public void Add(Suppliers newShipper)
        {
            _northwindContext.Suppliers.Add(newShipper);
            _northwindContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplierEliminar = _northwindContext.Suppliers.Find(id);
            _northwindContext.Suppliers.Remove(supplierEliminar);
            _northwindContext.SaveChanges();
        }


        public void Update(Suppliers shipper)
        {
            var supplierUpdate = _northwindContext.Suppliers.Find(shipper.SupplierID);
            supplierUpdate.CompanyName = shipper.CompanyName;
            _northwindContext.SaveChanges();
        }

        public Suppliers GetById(int id)
        {
            return _northwindContext.Suppliers.FirstOrDefault(s => s.SupplierID == id);
        }
    }
}
