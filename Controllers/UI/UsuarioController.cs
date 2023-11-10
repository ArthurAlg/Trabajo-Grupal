using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Controllers.UI
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<IdentityUser> users = _context.Users.ToList();
            return View("Index", users);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}