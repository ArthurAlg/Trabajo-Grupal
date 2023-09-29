using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;

        public CatalogoController(ILogger<CatalogoController> logger, 
        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var libros = from o in _context.DataLibros select o;
            return View(libros.ToList());
            //Con esto se saca los libros
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}