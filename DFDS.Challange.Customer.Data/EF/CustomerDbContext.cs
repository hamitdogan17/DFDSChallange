using DFDS.Challange.Customer.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Challange.Customer.Data.EF
{
    public partial class CustomerDbContext : DbContext
    {
        public CustomerDbContext() 
        {
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<tb_Customer> tb_Customer { get; set; }
        public DbSet<tb_Status> tb_Status { get; set; }
        public DbSet<tb_Nationality> tb_Nationality { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new tb_CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new tb_NationalityConfiguration());
            modelBuilder.ApplyConfiguration(new tb_CustomerStatusConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
