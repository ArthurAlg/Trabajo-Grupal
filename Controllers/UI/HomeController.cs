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
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Controllers.UI;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index(){
    var productos = _context.DataProductos.Where(libro => libro.Precio < 70M).ToList();
    return View(productos);
    }

    public async Task<IActionResult> DetailsHome(int? id){
        Producto? objProduct = await _context.DataProductos.FindAsync(id);
        if(objProduct == null){
            return NotFound();
        }
        return View(objProduct);
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

    public async Task<IActionResult> Add1(int? id){
        var userID = _userManager.GetUserName(User);
        if(userID == null){
            //no se ha logueado
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
            List<Producto> productos = new List<Producto>();
            return  View("Index",productos);
        }else{
            //ya esta logueado
            var producto = await _context.DataProductos.FindAsync(id);

            MiLista milista = new MiLista();
            milista.imgProducto = producto.ImageName;
            milista.Producto = producto;
            milista.Precio = producto.Precio; //precio del producto en ese momento
            milista.UserID = userID;
            _context.Add(milista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
