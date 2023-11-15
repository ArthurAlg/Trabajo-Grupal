using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;
using Trabajo_Grupal.Service;

namespace Trabajo_Grupal.Controllers.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactanosApiController : ControllerBase
    {
        private readonly ContactanosService _contactanosService;
        public ContactanosApiController(ContactanosService contactanosService)
        {
            _contactanosService = contactanosService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Contacto>>> List()
        {
            var forms = await _contactanosService.GetAll();
            if(forms == null)
                return NotFound();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetProducto(int? id)
        {
            var forms = await _contactanosService.Get(id);
            if(forms == null)
                return NotFound();
            return Ok(forms);
        }
    }
}