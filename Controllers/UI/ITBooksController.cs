using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo_Grupal.DTO;
using Trabajo_Grupal.Integrations;

namespace Trabajo_Grupal.Controllers.UI
{
    public class ITBooksController : Controller
    {
        private readonly ILogger<ITBooksController> _logger;
        private readonly ITBooksAPIIntegration _itbooks;

        public ITBooksController(ILogger<ITBooksController> logger, 
        ITBooksAPIIntegration itbooks)
        {
            _logger = logger;
            _itbooks = itbooks;
        }
        public async Task<IActionResult> Index()
        {
            List<SearchResultDTO> libros = await _itbooks.GetBooks();

            _logger.LogDebug($"Libros encontrados: {libros.Count}");
            return View(libros.FirstOrDefault());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}