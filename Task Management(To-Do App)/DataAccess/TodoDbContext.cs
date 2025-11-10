using Microsoft.EntityFrameworkCore;
using Task_Management_To_Do_App_.Models;
namespace Task_Management_To_Do_App_.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskModel> TaskTbl { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
