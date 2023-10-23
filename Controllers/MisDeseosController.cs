using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Controllers
{
    public class MisDeseosController : Controller
    {
        private readonly ILogger<MisDeseosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public MisDeseosController(ILogger<MisDeseosController> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {   var userIDSession = _userManager.GetUserName(User);

            //select proforma pr, product p WHERE join ... And pr.user = usuarion sesionado

            var items1 = from o in _context.DataMiLista select o;
            items1 = items1.Include(p => p.Producto).
                Where(w => w.UserID.Equals(userIDSession));

            var itemsCarrito1 = items1.ToList();
            dynamic model1 = new ExpandoObject();
            model1.elementosCarrito1 = itemsCarrito1;
            return View(model1);
        }

        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemcarrito1 = await _context.DataMiLista.FindAsync(id);
            _context.DataMiLista.Remove(itemcarrito1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}