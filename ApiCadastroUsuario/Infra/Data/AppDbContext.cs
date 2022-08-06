using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().HasKey(keyExpression: x => x.Id);
            modelBuilder.Entity<Endereco>().HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithOne(e => e.UsuarioEndereco)
                .HasForeignKey<Usuario>("IdEndereco");

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}
