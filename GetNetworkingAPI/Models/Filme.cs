using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetNetworkingAPI.Models
{
    public class Filme
    {
        [Key]
        public long? IdFilme { get; set; }
        public string NomeFilme { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Duracao { get; set; }
        public int VezesAssistidos { get; set; }
        public bool IsCurta { get; set; }
        public string CaminhoFilme { get; set; }
        public string CaminhoPoster { get; set; }
        public Categoria Categoria { get; set; }


        [NotMapped]
        public IFormFile ArquivoFilme { get; set; }

        [NotMapped]
        public IFormFile ArquivoPoster { get; set; }

        
    }
}
