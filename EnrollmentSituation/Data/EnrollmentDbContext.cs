using System.Data.Entity;   // Note EF6 namespace, NOT EF Core
using EnrollmentSituation.Models;

namespace EnrollmentSituation.Data
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext() : base("EnrollmentDbContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TeachAssignment> TeachAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeachAssignment>()
                .HasKey(t => new { t.InstrId, t.CourseCode, t.RoomId });

            modelBuilder.Entity<TeachAssignment>()
                .HasRequired(t => t.Room)
                .WithMany(r => r.TeachAssignments)
                .HasForeignKey(t => t.RoomId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.Room)
                .WithMany(r => r.Schedules)
                .HasForeignKey(s => s.RoomId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.Student)       // Assuming your Schedule has a Student navigation property
                .WithMany(st => st.Schedules)      // Assuming Student has a collection of Schedules
                .HasForeignKey(s => s.StudId)
                .WillCascadeOnDelete(false);       // Disable cascade delete here


            base.OnModelCreating(modelBuilder);
        }
    }
}
