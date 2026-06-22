using InstitutoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstitutoApp.Data
{
    public class ApplicationDbContex : DbContext
    {

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
        }
        
        //defino las tablas de la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }
        
        public DbSet<Curso> Cursos { get; set; }
        
        public DbSet<Matricula> Matriculas { get; set; }



        //configuro las relaciones entre las tablas de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //llama al metodo base para que se ejecute la configuracion por defecto del modelo de datos,
            base.OnModelCreating(modelBuilder);


            //campo correo unico
            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.Correo)
                .IsUnique();

            //campo nombre del curso unico
            modelBuilder.Entity<Curso>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            //relacion de 1 : N. (un estudiante muchas matriculas)
            modelBuilder.Entity<Matricula>()
                .HasOne(e => e.Estudiante)
                .WithMany(m => m.Matriculas)
                .HasForeignKey(m => m.EstudianteCedula);

            //relacion de 1 : N. (un curso muchas matriculas)
            modelBuilder.Entity<Matricula>()
                .HasOne(c => c.Curso)
                .WithMany(m => m.Matriculas)
                .HasForeignKey(m => m.CursoId);



        }


    }
}
