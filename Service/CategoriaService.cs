using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabajo_Grupal.Data;
using Trabajo_Grupal.Models;
using Trabajo_Grupal.Service;

namespace Trabajo_Grupal.Service
{
    public class CategoriaService
    {
        private readonly ILogger<ProductoService> _logger;
        private readonly ApplicationDbContext _context;

        public ProductoService(ILogger<ProductoService> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}