using Practica3.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Practica3.EF.MVC.Controllers
{
    public class BreakingBadController : Controller
    {
        // GET: BreakingBad
        private readonly BreakingBadService _breakingBadService;

        public BreakingBadController()
        {
            _breakingBadService = new BreakingBadService();
        }

        public ActionResult Index()
        {
            List<BreakingBadQuoteModel> quotes = _breakingBadService.GetRandomQuotes(3);
            return View(quotes);
        }
    }
}