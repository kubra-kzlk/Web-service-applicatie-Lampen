using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lampen.Models;

namespace lampen.Data
{
    public class StyleConfiguration : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable("Styles");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("style_id");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .IsRequired(false)
                .HasMaxLength(500); 
        }
    }
}