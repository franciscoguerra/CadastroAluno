using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CadastroAluno.Context
{
    public class CadastroAlunoDbContext : DbContext
    {
        public CadastroAlunoDbContext(DbContextOptions<CadastroAlunoDbContext> options)
                    : base(options)
        {
        }


        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=CadastroAlunoNovo;User Id=sa;Password=Deusmeam@27;TrustServerCertificate=true;");

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoModel>()
                .HasMany(a => a.Turmas)
                .WithMany(t => t.Alunos)
                .UsingEntity(j => j.ToTable("AlunoTurma"));

            modelBuilder.Entity<TurmaModel>()
                .HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CursoId);
        }

    }
}
