using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lampen.Models;

namespace lampen.Data
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("manufacturer_id");

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(m => m.Country)
                .HasColumnName("country")
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(m => m.Description)
                .HasColumnName("description")
                .IsRequired(false)
                .HasMaxLength(500); 
        }
    }
}