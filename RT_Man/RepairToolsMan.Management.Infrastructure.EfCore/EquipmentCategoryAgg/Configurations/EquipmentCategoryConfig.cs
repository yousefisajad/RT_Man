using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairToolsMan.Domain.EquipmentCategoryAgg;

namespace RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Configurations
{
    public class EquipmentCategoryConfig : IEntityTypeConfiguration<EquipmentCategory>
    {
        public void Configure(EntityTypeBuilder<EquipmentCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Name).HasMaxLength(255).IsRequired();
            builder.Property(c=>c.Description).HasMaxLength(500);
            builder.Property(c=>c.Picture).HasMaxLength(1000);
            builder.Property(c=>c.PictureAlt).HasMaxLength(255);
            builder.Property(c=>c.PictureTitle).HasMaxLength(500);
            builder.Property(c=>c.KeyWord).HasMaxLength(80).IsRequired();
            builder.Property(c=>c.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(c=>c.Slug).HasMaxLength(300).IsRequired();

        }
    }
}
