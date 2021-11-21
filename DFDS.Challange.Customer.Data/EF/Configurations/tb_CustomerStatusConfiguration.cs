using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFDS.Challange.Customer.Data.EF.Configurations
{
    public partial class tb_CustomerStatusConfiguration : IEntityTypeConfiguration<tb_Status>
    {
        public void Configure(EntityTypeBuilder<tb_Status> builder)
        {
            builder.HasKey(e => e.StatusRef);
            builder.ToTable("tb_Status", "dbo");


            builder.Property(e => e.StatusRef).ValueGeneratedNever().UseIdentityColumn();
            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<tb_Status> builder);
    }
}
