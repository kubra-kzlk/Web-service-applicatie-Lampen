using lampen.Models;
using Microsoft.EntityFrameworkCore;

namespace lampen.Data
{
    public static class SeedData
    {
        public static void SeedAppData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Style>().HasData(
                new Style { Id = 1, Name = "Modern", Description = "Sleek and contemporary designs." },
                new Style { Id = 2, Name = "Vintage", Description = "Classic designs with a nostalgic feel." },
                new Style { Id = 3, Name = "Industrial", Description = "Rugged and raw designs inspired by factories." },
                new Style { Id = 4, Name = "Minimalist", Description = "Simple and functional designs." },
                new Style { Id = 5, Name = "Art Deco", Description = "Bold geometric shapes and rich colors." }
                );

            modelBuilder.Entity<Lamp>().HasData(
                new Lamp { Id = 1, Name = "LED Desk Lamp", Description = "A modern LED desk lamp with adjustable brightness.", Price = 29.99m, IsActive = true, Date = "2023-01-01", Photo = "https://example.com/images/led_desk_lamp.jpg", Color = "White", ManufacturerId = 1 },
                new Lamp { Id = 2, Name = "Vintage Floor Lamp", Description = "A stylish vintage floor lamp that adds character to any room.", Price = 89.99m, IsActive = true, Date = "2023-01-02", Photo = "https://example.com/images/vintage_floor_lamp.jpg", Color = "Bronze", ManufacturerId = 2 },
                new Lamp { Id = 3, Name = "Industrial Pendant Light", Description = "An industrial-style pendant light perfect for kitchens.", Price = 49.99m, IsActive = true, Date = "2023-01-03", Photo = "https://example.com/images/industrial_pendant_light.jpg", Color = "Black", ManufacturerId = 3 },
                new Lamp { Id = 4, Name = "Minimalist Table Lamp", Description = "A sleek minimalist table lamp that fits any decor.", Price = 39.99m, IsActive = true, Date = "2023-01-04", Photo = "https://example.com/images/minimalist_table_lamp.jpg", Color = "Gray", ManufacturerId = 4 },
                new Lamp { Id = 5, Name = "Art Deco Chandelier", Description = "An elegant Art Deco chandelier that adds luxury to any space.", Price = 199.99m, IsActive = true, Date = "2023-01-05", Photo = "https://example.com/images/art_deco_chandelier.jpg", Color = "Gold", ManufacturerId = 5 }
                );

            modelBuilder.Entity<Manufacturer>().HasData(
                    new Manufacturer { Id = 1, Name = "Philips", Country = "Netherlands", Description = "A leading manufacturer of lighting products." },
                    new Manufacturer { Id = 2, Name = "Osram", Country = "Germany", Description = "A global leader in lighting solutions." },
                    new Manufacturer { Id = 3, Name = "GE Lighting", Country = "USA", Description = "Innovative lighting solutions for various applications." },
                    new Manufacturer { Id = 4, Name = "Cree", Country = "USA", Description = "Specializes in LED lighting technology." },
                    new Manufacturer { Id = 5, Name = "Sylvania", Country = "USA", Description = "Offers a wide range of lighting products." }
                    );
        }
    }
}
