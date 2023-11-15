using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;
using Trabajo_Grupal.Service;
using Microsoft.EntityFrameworkCore;

namespace Trabajo_Grupal.Controllers.UI
{
    public class PedidoController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly UserManager<IdentityUser> _userManager;
        public PedidoController(PedidoService pedidoService,
        UserManager<IdentityUser> userManager)
        {
            _pedidoService = pedidoService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userIDSession = _userManager.GetUserName(User);

            var listapedido = await _pedidoService.MostrarCliente(userIDSession);
            return View(listapedido);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {   
            return View("Error!");
        }
    }
}