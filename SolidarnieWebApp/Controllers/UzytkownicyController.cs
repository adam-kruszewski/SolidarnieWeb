using SolidarnieWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolidarnieWebApp.Controllers
{
    public class UzytkownicyController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListaUzytkownikowModel();
            return View(model);
        }
    }
}