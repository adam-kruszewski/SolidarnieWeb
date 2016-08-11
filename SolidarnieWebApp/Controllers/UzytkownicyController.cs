using SolidarnieWebApp.Models;
using System.Web.Mvc;
using System;

namespace SolidarnieWebApp.Controllers
{
    public class UzytkownicyController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListaUzytkownikowModel();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UzytkownikEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UzytkownikEditModel form)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Coś poszło nie tak");
                return View(form);
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = DajModelDoEdycji(id);
            return View(model);
        }

        private UzytkownikEditModel DajModelDoEdycji(int id)
        {
            return new UzytkownikEditModel
            {
                ID = 10,
                Nazwa = "Użytkownik do edycji",
                Email = "mail@mail.com"
            };
        }

        [HttpPost]
        public ActionResult Edit(UzytkownikEditModel form)
        {
            if (ModelState.IsValid)
            {

            }

            return View(form);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}