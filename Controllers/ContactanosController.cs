using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo_Grupal.Models;


namespace Trabajo_Grupal.Controllers
{
    public class ContactanosController : Controller
    {
        private readonly ILogger<ContactanosController> _logger;

        public ContactanosController(ILogger<ContactanosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contacto objContacto)
        {
            ViewData["Message"] = string.Concat("Se registro el contacto ",objContacto.Name);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}