using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;
using Trabajo_Grupal.DTO;
using Trabajo_Grupal.Integrations;

namespace Trabajo_Grupal.Controllers.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class ITBooksApiController : ControllerBase
    {
        private readonly ITBooksAPIIntegration _itbooks;

        public ITBooksApiController(ITBooksAPIIntegration itbooks)
        {
            _itbooks = itbooks;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(string searchString)
        {
            List<ITBooksDTO> searchResults = await _itbooks.GetBooks(searchString);

            if (searchResults != null && searchResults.Any())
            {
                return Ok(searchResults);
            }
            else
            {
                return NotFound(); // Puedes personalizar el mensaje para el caso de no encontrar resultados.
            }
        }
    }
}