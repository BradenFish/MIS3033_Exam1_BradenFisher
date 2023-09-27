using Microsoft.EntityFrameworkCore;

namespace a
{
    public class ExamDB:DbContext
    {// we need to add database tables here DBSet<>

        public DbSet<Patient> patTbl { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlite("Data Source = exam.db");
        }
    }
}
