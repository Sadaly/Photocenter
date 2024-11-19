using Microsoft.EntityFrameworkCore;
using Фотоцентр.Models;

namespace Фотоцентр.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<ActionLog> ActionLogs { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Photographer> Photographers { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.Property(o => o.Total_Amount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Payment>()
				.Property(p => p.Amount_Paid)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Service>()
				.Property(s => s.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Photographer>()
				.Property(p => p.Rating)
				.HasPrecision(2, 1);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Фотоцентр;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
