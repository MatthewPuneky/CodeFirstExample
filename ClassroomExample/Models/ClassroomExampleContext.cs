using Microsoft.EntityFrameworkCore;

namespace ClassroomExample.Models
{
    public class ClassroomExampleContext : DbContext
    {
        public ClassroomExampleContext(DbContextOptions<ClassroomExampleContext> options)
            : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<StudentClass> StudentClass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.TeacherId);
            
            modelBuilder.Entity<StudentClass>()
                .HasKey(x => new {x.StudentId, x.ClassId});

            modelBuilder.Entity<StudentClass>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentClasses)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentClass>()
                .HasOne(x => x.Class)
                .WithMany(x => x.StudentClasses)
                .HasForeignKey(x => x.ClassId);
        }
    }
}
