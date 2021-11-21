using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFDS.Challange.Customer.Data.EF.Configurations
{
    public partial class tb_CustomerConfiguration : IEntityTypeConfiguration<tb_Customer>
    {
        public void Configure(EntityTypeBuilder<tb_Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("tb_Customer", "dbo");

            builder.Property(e => e.Name).HasMaxLength(20);
            builder.Property(e => e.Surname).HasMaxLength(20);

            builder.HasOne(d => d.NationalityRefNavigation)
               .WithMany(p => p.tb_Customer)
               .HasForeignKey(d => d.NationalityRef)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_tb_Customer_tb_Status");

            builder.HasOne(d => d.StatusRefNavigation)
               .WithMany(p => p.tb_Customer)
               .HasForeignKey(d => d.StatusRef)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_tb_Customer_tb_Nationality");

            builder.HasQueryFilter(c => c.IsDeleted == false);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<tb_Customer> builder);
    }
}
