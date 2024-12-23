using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lampen.Models;

namespace lampen.Data
{
    public class LampConfiguration : IEntityTypeConfiguration<Lamp>
    {
        public void Configure(EntityTypeBuilder<Lamp> builder)
        {
            builder.ToTable("Lamps");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("lamp_id");

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(l => l.Description)
                .HasColumnName("description")
                .IsRequired(false)
                .HasMaxLength(500); 

            builder.Property(l => l.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(l => l.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(l => l.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(l => l.Photo)
                .HasColumnName("photo")
                .IsRequired(false)
                .HasMaxLength(255); 

            builder.Property(l => l.Color)
                .HasColumnName("color")
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(l => l.ManufacturerId)
                .HasColumnName("manufacturer_id")
                .IsRequired();

            builder.HasOne<Manufacturer>()
                .WithMany()
                .HasForeignKey(l => l.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}