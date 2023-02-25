using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetNetworkingAPI.Models
{
    public class Categoria
    {
        [Key]
        public long? IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public List<Filme> Filme { get; set; }
        public List<Serie> Serie { get; set; }
    }
}
