using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;

namespace Trabajo_Grupal.Service
{
    public class ContactanosService
    {
        private readonly ILogger<ContactanosService> _logger;
        private readonly ApplicationDbContext _context;

        public ContactanosService(ILogger<ContactanosService> logger,
        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Contacto> Crear(Contacto contacto)
        {
            _context.Add(contacto);
            await _context.SaveChangesAsync();
            return contacto;
        }

        public async Task<List<Contacto?>> GetAll()
        {
            if(_context.DataContactos == null )
                return null;
            return await _context.DataContactos.ToListAsync();
        }

        public async Task<Contacto?> Get(int? id)
        {
            if (id == null || _context.DataContactos == null)
            {
                return null;
            }

            var contactanos = await _context.DataContactos.FindAsync(id);
            if (contactanos == null)
            {
                return null;
            }
            return contactanos;
        }
    }
}