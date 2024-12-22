using Microsoft.EntityFrameworkCore;
using lampen.Data;
using lampen.Models;

namespace lampen.Services
{
    public class ManufacturerServiceDb : IManufacturerData
    {
        private readonly DatabaseContext _context;

        public ManufacturerServiceDb(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer?> GetManufacturerById(int id)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Manufacturer> CreateManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }

        public async Task UpdateManufacturer(Manufacturer manufacturer)
        {
            var existingManufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == manufacturer.Id);
            if (existingManufacturer != null)
            {
                existingManufacturer.Name = manufacturer.Name;
                existingManufacturer.Country = manufacturer.Country;
                existingManufacturer.Description = manufacturer.Description;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
