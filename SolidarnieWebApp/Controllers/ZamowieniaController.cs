using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly IDefinicjeZamowieniaService definicjeService;

        public ZamowieniaController(
            IDefinicjeZamowieniaService definicjeService)
        {
            this.definicjeService = definicjeService;
        }

        public ActionResult Index()
        {
            var model = new ListaDefinicjiZamowieniaModel(
                definicjeService.SzukajWszystkich());
            return View(model);
        }
    }
}