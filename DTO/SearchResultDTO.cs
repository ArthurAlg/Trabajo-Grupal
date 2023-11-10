using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Grupal.DTO
{
    public class SearchResultDTO{
    public string Error { get; set; }
    public string Total { get; set; }
    public List<ITBooksDTO> Books { get; set; }
    }
}