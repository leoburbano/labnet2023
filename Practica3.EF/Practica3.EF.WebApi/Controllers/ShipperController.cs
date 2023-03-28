using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Practica3.EF.WebApi.Controllers
{
    public class ShipperController : ApiController
    {

        //GET api/shipper
        public IHttpActionResult Get()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            List<ShipperModel> result = shipperLogic.GetAll().Select(s => new ShipperModel { Id = s.ShipperID, Name = s.CompanyName, Phone = s.Phone }).ToList();

            return Ok(result);
        }

        //GET api/shipper/3

        public IHttpActionResult Get(int id)
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            List<ShipperModel> result = shipperLogic.GetAll().Select(s => new ShipperModel { Id = s.ShipperID, Name = s.CompanyName, Phone = s.Phone }).ToList();

            try
            {
                if(id == 0)
                {
                    return BadRequest("Id es requerido");
                }
                return Ok(result.FirstOrDefault(s => s.Id == id));
            }
            catch { 
                return InternalServerError();
            }
        }

        //POST api/shipper
        public IHttpActionResult Post(ShipperModel model)
        {
            Shippers shipper = new Shippers { CompanyName = model.Name, Phone = model.Phone };
            ShipperLogic shipperLogic = new ShipperLogic();
            shipperLogic.Add(shipper);
            return Ok(shipper);
        }

        //PUT api/shipper/3
        public IHttpActionResult Put(int id, ShipperModel model)
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            Shippers shipper = shipperLogic.GetById(id);

            if (shipper == null)
            {
                return NotFound();
            }

            shipper.CompanyName = model.Name;
            shipper.Phone = model.Phone;

            shipperLogic.Update(shipper);

            return Ok(shipper);
        }

        //DELETE api/shipper/3

        public IHttpActionResult Delete(int id)
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            Shippers shipper = shipperLogic.GetById(id);

            if (shipper == null)
            {
                return NotFound();
            }

            shipperLogic.Delete(id);

            return Ok();
        }

    }
}
