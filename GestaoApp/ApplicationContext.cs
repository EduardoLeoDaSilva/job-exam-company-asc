using GestaoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasKey(x => x.UsuarioId);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Materia>().HasKey(x => x.MateriaId);
            modelBuilder.Entity<Materia>().ToTable("Materias");

            modelBuilder.Entity<Turma>().HasKey(x => x.TurmaId);
            modelBuilder.Entity<Turma>().ToTable("Turmas");

            modelBuilder.Entity<Aluno>().HasKey(x => x.AlunoId);
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            modelBuilder.Entity<Prova>().HasKey(x => x.ProvaId);
            modelBuilder.Entity<Prova>().ToTable("Provas");

            modelBuilder.Entity<Resultado>().HasKey(x => x.ResultadoId);
            modelBuilder.Entity<Resultado>().ToTable("Resultados");


            //relações
            modelBuilder.Entity<Prova>().HasOne(x => x.Materia).WithMany(x => x.Provas);
            modelBuilder.Entity<MateriaAluno>().HasKey(x => new { x.MateriaId, x.AlunoId});

            modelBuilder.Entity<MateriaAluno>().HasOne(x => x.Aluno).WithMany(x => x.MateriaAluno).HasForeignKey(x => x.AlunoId);
            modelBuilder.Entity<MateriaAluno>().HasOne(x => x.Materia).WithMany(x => x.MateriaAluno).HasForeignKey(x => x.MateriaId);

            modelBuilder.Entity<Resultado>().HasOne(x => x.Materia);
            modelBuilder.Entity<Resultado>().HasMany(x => x.Provas);

            modelBuilder.Entity<Resultado>().HasOne(x => x.Aluno).WithMany(x => x.Resultados);

        }
    }
}
