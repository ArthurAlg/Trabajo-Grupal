using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Trabajo_Grupal.Controllers.UI
{
    public class NosotrosController : Controller
    {
        private readonly ILogger<NosotrosController> _logger;

        public NosotrosController(ILogger<NosotrosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Direccion()
        {
            return View("Direccion");
        }

        public IActionResult PreguntasFrecuentes()
        {
            return View("PreguntasFrecuentes");
        }

        public IActionResult LibrodeReclamaciones()
        {
            return View("LibrodeReclamaciones");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}