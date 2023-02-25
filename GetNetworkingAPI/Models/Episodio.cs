using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GetNetworkingAPI.Models
{
    public class Episodio
    {
        [Key]
        public long? IdEpisodio { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Descricao { get; set; }
        public int Temporada { get; set; }
        public string CaminhoImagem { get; set; }
        public string CaminhoEpisodio { get; set; }
        public Serie Serie { get; set; }

        [NotMapped]
        public IFormFile ArquivoImagem { get; set; }

        [NotMapped]
        public IFormFile ArquivoEpisodio { get; set; }
    }
}
