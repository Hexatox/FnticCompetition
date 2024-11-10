// DAL/AttendanceDbContext.cs

using DL.FnticCompetition.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.FnticCompetition
{
    public class AttendanceDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options):base(options)
        {
            
        }
       
    }
}