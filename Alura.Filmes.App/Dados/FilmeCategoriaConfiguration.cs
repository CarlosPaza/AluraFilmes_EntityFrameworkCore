using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeCategoriaConfiguration : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");
            builder.Property<int>("film_id").IsRequired();
            builder.Property<byte>("category_id").IsRequired();
            builder.Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            builder.HasKey("film_id", "category_id");
            builder.HasOne(fa => fa.Filme)
                .WithMany(f => f.Categorias)
                .HasForeignKey("film_id");
            builder.HasOne(fa => fa.Categoria)
                .WithMany(f => f.Filmes)
                .HasForeignKey("category_id");
        }
    }
}
