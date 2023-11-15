using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabajo_Grupal.DTO;
using Trabajo_Grupal.Integrations;

namespace Trabajo_Grupal.Controllers.Rest
{
    [ApiController]
    [Route("api/itbooks")]
    public class ITBooksApiController : ControllerBase
    {
        private readonly ITBooksAPIIntegration _itBooksAPIIntegration;

        public ITBooksApiController(ITBooksAPIIntegration itBooksAPIIntegration)
        {
            _itBooksAPIIntegration = itBooksAPIIntegration;
        }

        [HttpGet("search/{query}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BookDTO>>> SearchBooks(string query)
        {
            try
            {
                var searchResults = await _itBooksAPIIntegration.GetBooks();

                if (searchResults == null || searchResults.Count == 0)
                {
                    return NotFound();
                }

                var filteredBooks = searchResults
                    .SelectMany(result => result.Books)
                    .Where(book => book.title.Contains(query, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredBooks.Count == 0)
                {
                    return NotFound();
                }

                return Ok(filteredBooks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en la API: {ex.Message}");
            }
        }
    }
}