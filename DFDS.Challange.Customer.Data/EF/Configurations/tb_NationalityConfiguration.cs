using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFDS.Challange.Customer.Data.EF.Configurations
{
    public partial class tb_NationalityConfiguration : IEntityTypeConfiguration<tb_Nationality>
    {
        public void Configure(EntityTypeBuilder<tb_Nationality> builder)
        {
            builder.HasKey(e => e.NationalityRef);
            builder.ToTable("tb_Nationality", "dbo");


            builder.Property(e => e.NationalityRef).ValueGeneratedNever();

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<tb_Nationality> builder);
    }
}
