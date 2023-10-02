using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Trabajo_Grupal.Data;

namespace Trabajo_Grupal.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context, ILogger<CatalogoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index() {
            var productos = from o in _context.DataProducto select o;
            return View(productos.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}