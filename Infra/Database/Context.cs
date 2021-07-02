using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imovel>()
                .HasKey(p => p.id);

            modelBuilder.Entity<Imovel>()
                .Property(p => p.cidade).HasMaxLength(100);

            modelBuilder.Entity<Imovel>()
                .Property(p => p.bairro).HasMaxLength(100);

            modelBuilder.Entity<Imovel>()
                .Property(p => p.quantidade).HasMaxLength(15);

            modelBuilder.Entity<Imovel>()
                .Property(p => p.valor).HasColumnType("double");
        }

    }
}

