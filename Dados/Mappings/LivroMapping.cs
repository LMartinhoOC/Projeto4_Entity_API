using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .ToTable("Livros");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(l => l.Autor)
                .HasColumnName("Autor")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(l => l.Isbn)
                .HasColumnName("ISBN")
                .HasMaxLength(13);

            builder
                .Property(l => l.Deletado)
                .HasColumnName("Deleted");
        }
    }
}
