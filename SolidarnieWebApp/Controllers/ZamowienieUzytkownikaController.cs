﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kruchy.Core.Autentykacja;
using Kruchy.Core.Mapowanie;
using Kruchy.Zakupy.Services;
using SolidarnieWebApp.Models;

namespace SolidarnieWebApp.Controllers
{
    public class ZamowienieUzytkownikaController : Controller
    {
        private readonly IUzytkownikProvider uzytkownikProvider;
        private readonly IDefinicjeZamowieniaService definicjeService;

        public ZamowienieUzytkownikaController(
            IUzytkownikProvider uzytkownikProvider,
            IDefinicjeZamowieniaService definicjeService)
        {
            this.uzytkownikProvider = uzytkownikProvider;
            this.definicjeService = definicjeService;
        }

        public ActionResult Index(int definicjaID)
        {
            var definicja = definicjeService.DajWgID(definicjaID);

            var editModel = definicja.Mapuj<ZamowienieEditModel>();

            editModel.Uzytkownik = uzytkownikProvider.DajZalogowanego();
            return View(editModel);
        }
    }
}