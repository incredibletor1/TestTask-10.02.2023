using Microsoft.EntityFrameworkCore;


namespace TestTask_10._02._2023.Models.Context
{
    public class TestTaskDbContext : DbContext, ITestTaskDbContext
    {
        public TestTaskDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .Entity<Employee>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder
            .Entity<Employee>()
            .Property(u => u.FullName)
            .IsRequired();

            builder
            .Entity<Employee>()
            .Property(u => u.BirthDate)
            .IsRequired();

            builder
            .Entity<Position>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder
            .Entity<Position>()
            .Property(u => u.Name)
            .IsRequired();

            builder
            .Entity<Position>()
            .Property(u => u.Grade)
            .IsRequired();
        }
    }
}
