using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairToolsMan.Domain.EquipmentAgg;

namespace RepairToolsMan.Management.Infrastructure.EfCore.EquipmentAgg.Configurations
{
    public class EquipmentConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Code).HasMaxLength(15).IsRequired();
            builder.Property(c => c.ShortDescription).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Picture).HasMaxLength(1000);
            builder.Property(c => c.PictureAlt).HasMaxLength(255);
            builder.Property(c => c.PictureTitle).HasMaxLength(500);
            builder.Property(c => c.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(c => c.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Slug).HasMaxLength(300).IsRequired();
            builder.HasOne(c => c.EquipmentCategory).WithMany(c => c.Equipments)
                .HasForeignKey(c=>c.CategoryId);

        }
    }
}
