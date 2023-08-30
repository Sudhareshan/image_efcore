using Microsoft.EntityFrameworkCore;

namespace Image.Models
{
    public class EmployeDbContext:DbContext
    {
        public EmployeDbContext(DbContextOptions<EmployeDbContext> options):base(options)
        {
            
        }
        public DbSet<EmployModel> Employes { get; set; }
        public DbSet<HobbyModel> Hobbies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<EmployModel>()
            .HasMany(e => e.Hobbies)
            .WithMany()
            .UsingEntity(j => j.ToTable("EmployeeHobbies"));

        }
    }
}
