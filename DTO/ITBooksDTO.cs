using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Grupal.DTO
{
    public class ITBooksDTO
    {
        public string? title { get; set; }
        public string? subtitle { get; set; }
        public string? isbn13 { get; set; }
        public decimal price { get; set; }
        public string? ImageName { get; set;}
        public string? url { get; set;}
    }
}