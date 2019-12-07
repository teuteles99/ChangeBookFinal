using Microsoft.EntityFrameworkCore;
using ChangeBook.Models;

namespace ChangeBook.Data
{
    public class ChangeBookContext : DbContext
    {
        public ChangeBookContext(DbContextOptions<ChangeBookContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Chamado> Chamado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Livros)
                .HasForeignKey(l => l.UsuarioId)
                .HasPrincipalKey(u => u.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Chamados)
                .HasForeignKey(c => c.UsuarioId)
                .HasPrincipalKey(u => u.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Livro>()
                .HasOne(l => l.Genero)
                .WithMany(g => g.Livros)
                .HasForeignKey(l => l.GeneroId)
                .HasPrincipalKey(g => g.GeneroId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
