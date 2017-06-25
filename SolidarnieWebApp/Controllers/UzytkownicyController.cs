using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Kruchy.Uzytkownicy.Domain;
using Kruchy.Uzytkownicy.Services;
using SolidarnieWebApp.Authentication;
using SolidarnieWebApp.Models;
using SolidarnieWebApp.Walidacja;

namespace SolidarnieWebApp.Controllers
{
    [WymagaLogowania]
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
            }
            else
            {
                if (uzytkownicyService.Dodaj(
                        new DodanieUzytkownikaRequest
                        {
                            Nazwa = form.Nazwa,
                            Email = form.Email,
                            Haslo = form.Haslo,
                            PowtorzenieHasla = form.PowtorzenieHasla
                        },
                        this.DajListeneraWalidacji()) != null)
                    return RedirectToAction("Index");
            }
            return View(form);
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
                        Nazwa = form.Nazwa,
                        Haslo = form.Haslo,
                        PowtorzenieHasla = form.PowtorzenieHasla
                    },
                    this.DajListeneraWalidacji()))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(form);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}