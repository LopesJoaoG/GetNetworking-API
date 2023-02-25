using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetNetworkingAPI.Models
{
    public class Serie
    {
        [Key]
        public long? IdSerie { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int VezesAssistido { get; set; }
        public int Temporadas { get; set; }
        public int Episodios { get; set; }
        public string Descricao { get; set; }
        public string CaminhoPoster { get; set; }
        public Categoria Categoria { get; set; }

        [NotMapped]
        public IFormFile ArquivoPoster { get; set; }
    }
}
