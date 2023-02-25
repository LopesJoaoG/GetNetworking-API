using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GetNetworkingAPI.Models;

namespace GetNetworkingAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GetNetworkingAPI.Models.Categoria> Categoria { get; set; }
        public DbSet<GetNetworkingAPI.Models.Filme> Filme { get; set; }
        public DbSet<GetNetworkingAPI.Models.Serie> Serie { get; set; }
        public DbSet<GetNetworkingAPI.Models.Episodio> Episodio { get; set; }
    }
}
