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

            var itemsMiLista = items1.ToList();
            
            
            
            //MEMORIA
            dynamic model1 = new ExpandoObject();
            model1.elementosMiLista = itemsMiLista;
            return View(model1);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemMiLista = await _context.DataMiLista.FindAsync(id);
            if (itemMiLista == null)
            {
                return NotFound();
            }
            return View(itemMiLista);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            
            if(userID == null){
                //no se ha logueado
                 ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Index",productos);
            }else{
                //ya esta logueado
               var producto = await _context.DataProductos.FindAsync(id);

                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio; //precio del producto en ese momento
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, [Bind("Id,Cantidad,Precio,UserID")] MiLista itemMiLista)
        {
            if (id != itemMiLista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemMiLista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DataMiLista.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemMiLista);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemMiLista = await _context.DataMiLista.FindAsync(id);
            _context.DataMiLista.Remove(itemMiLista);
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