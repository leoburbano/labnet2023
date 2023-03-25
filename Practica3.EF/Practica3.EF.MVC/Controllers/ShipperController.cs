using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica3.EF.MVC.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        public ActionResult Index()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            List<ShipperViewModel> result = shipperLogic.GetAll().Select(s => new ShipperViewModel { Id = s.ShipperID, Name = s.CompanyName, Phone = s.Phone}).ToList();
            return View(result);
        }

        public ActionResult Eliminar(int id)
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            shipperLogic.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int id) 
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            ShipperViewModel model = new ShipperViewModel();
            Shippers ship = shipperLogic.GetById(id);
            var shipper = ship;
            model.Id = shipper.ShipperID;
            model.Name = shipper.CompanyName;
            model.Phone = shipper.Phone;

            return View(model);
        }

        [HttpPost]
        public ActionResult Actualizar(ShipperViewModel model)
        {
            Shippers shipper = (new Shippers { ShipperID = model.Id, CompanyName = model.Name, Phone = model.Phone });
            ShipperLogic shipperLogic = new ShipperLogic();
            shipperLogic.Update(shipper);

            return RedirectToAction("Index");
        }

        public ActionResult Crear(Shippers shipper)
        {
            var ship = new Shippers();
            ShipperViewModel model = new ShipperViewModel();
            
            model.Name = ship.CompanyName;
            model.Phone = ship.Phone;


            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(ShipperViewModel model)
        {
            Shippers shipper = (new Shippers { CompanyName = model.Name, Phone = model.Phone });
            ShipperLogic shipperLogic = new ShipperLogic();

            shipperLogic.Add(shipper);

            return RedirectToAction("Index");
        }
    }
}