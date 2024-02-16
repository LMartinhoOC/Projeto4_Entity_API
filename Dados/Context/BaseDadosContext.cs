using Dados.Mappings;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Context
{
    public class BaseDadosContext : DbContext
    {
        public BaseDadosContext(DbContextOptions<BaseDadosContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMapping());
        }
    }
}
