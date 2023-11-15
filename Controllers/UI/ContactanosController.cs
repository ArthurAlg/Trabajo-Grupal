using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;
using Trabajo_Grupal.Service;

namespace Trabajo_Grupal.Controllers.UI
{
    public class ContactanosController : Controller
    {
        private readonly ContactanosService _contactanosService;

        public ContactanosController(ContactanosService contactanosService)
        {
            _contactanosService = contactanosService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contacto objContacto)
        {
            var contactos = await _contactanosService.Crear(objContacto);
            ViewData["Message"] = string.Concat("Estimado " , contactos.Name, " , te estaremos contactando pronto.");
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}