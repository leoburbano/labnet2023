using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practica3.EF.WebApi.Controllers
{
    public class SupplierController : ApiController
    {
        //GET api/supplier
        public IHttpActionResult Get()
        {
            SupplierLogic supplierLogic = new SupplierLogic();
            List<SupplierModel> result = supplierLogic.GetAll().Select(s => new SupplierModel { SupplierID = s.SupplierID, CompanyName = s.CompanyName, ContactName = s.ContactName, ContactTitle = s.ContactTitle, Address = s.Address, City = s.City }).ToList();

            return Ok(result);
        }

        //GET api/supplier/3

        public IHttpActionResult Get(int id)
        {
            SupplierLogic supplierLogic = new SupplierLogic();

            List<SupplierModel> result = supplierLogic.GetAll().Select(s => new SupplierModel { SupplierID = s.SupplierID, CompanyName = s.CompanyName, ContactName = s.ContactName, ContactTitle = s.ContactTitle, Address = s.Address, City = s.City }).ToList();

            try
            {
                if (id == 0)
                {
                    return BadRequest("Id es requerido");
                }
                return Ok(result.FirstOrDefault(s => s.SupplierID == id));
            }
            catch
            {
                return InternalServerError();
            }
        }

        //POST api/supplier
        public IHttpActionResult Post(SupplierModel model)
        {
            Suppliers supplier = new Suppliers { CompanyName = model.CompanyName, ContactName = model.ContactName, ContactTitle = model.ContactTitle, Address = model.Address, City = model.City };
            SupplierLogic supplierLogic = new SupplierLogic();
            supplierLogic.Add(supplier);
            return Ok(supplier);
        }

        //PUT api/supplier/3
        public IHttpActionResult Put(int id, SupplierModel model)
        {
            SupplierLogic supplierLogic = new SupplierLogic();

            Suppliers supplier = supplierLogic.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            supplier.CompanyName = model.CompanyName;
            supplier.ContactName = model.ContactName;
            supplier.ContactTitle = model.ContactTitle;
            supplier.Address = model.Address;
            supplier.City = model.City;

            supplierLogic.Update(supplier);

            return Ok(supplier);
        }

        //DELETE api/supplier/3
        public IHttpActionResult Delete(int id)
        {
            SupplierLogic supplierLogic = new SupplierLogic();
            Suppliers supplier = supplierLogic.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            supplierLogic.Delete(id);

            return Ok();
        }

    }
}
