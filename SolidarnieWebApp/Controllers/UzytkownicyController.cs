using System.Linq;
using System.Web.Mvc;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Services;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class UzytkownicyController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;

        public UzytkownicyController(
            IUzytkownicyService uzytkownicyService)
        {
            this.uzytkownicyService = uzytkownicyService;
        }

        public ActionResult Index()
        {
            var u = uzytkownicyService.SzukajWszystkich();

            var model = new ListaUzytkownikowModel();
            model.Uzytkownicy = u.Select(o => DajUzytkownikRowModel(o)).ToList();
            return View(model);
        }

        private UzytkownikRowModel DajUzytkownikRowModel(Uzytkownik o)
        {
            return new UzytkownikRowModel
            {
                ID = o.ID,
                Nazwa = o.Nazwa,
                Email = o.Email
            };
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
            {
                uzytkownicyService
                    .Dodaj(
                        new DodanieUzytkownikaRequest
                        {
                            Nazwa = form.Nazwa,
                            Email = form.Email,
                            Haslo = "123"
                        });
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var model = DajModelDoEdycji(id);
            return View(model);
        }

        private UzytkownikEditModel DajModelDoEdycji(int id)
        {
            var view = uzytkownicyService.DajWgID(id);
            return new UzytkownikEditModel
            {
                ID = id,
                Nazwa = view.Nazwa,
                Email = view.Email
            };
        }

        [HttpPost]
        public ActionResult Edit(UzytkownikEditModel form)
        {
            if (ModelState.IsValid)
            {
                if (uzytkownicyService.Zmien(
                    new ModyfikacjaUzytkownikaRequest
                    {
                        ID = form.ID,
                        Email = form.Email,
                        Nazwa = form.Nazwa
                    }))
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "coś poszło nie tak przy aktualizacji");

            return View(form);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}