using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Grupal.DTO
{
   public class BookDTO
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string isbn13 { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

    public class SearchResultDTO
    {
        public string total { get; set; }
        public string page { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}