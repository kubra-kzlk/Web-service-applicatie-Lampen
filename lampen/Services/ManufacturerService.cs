using lampen.Models;

namespace lampen.Services
{
    public class ManufacturerService : IManufacturerData
    {
        private readonly List<Manufacturer> _manufacturers = new()
        {
           new Manufacturer { Id = 1, Name = "Philips", Country = "Netherlands", Description = "Global leader in lighting solutions." },
            new Manufacturer { Id = 2, Name = "IKEA", Country = "Sweden", Description = "Known for affordable and stylish home decoration." }
        };

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await Task.FromResult(_manufacturers);
        }

        public async Task<Manufacturer?> GetManufacturerById(int id)
        {
            return await Task.FromResult(_manufacturers.FirstOrDefault(m => m.Id == id));
        }
        public async Task<Manufacturer> CreateManufacturer(Manufacturer manufacturer)
        {
            // Genereer een nieuw ID
            var newId = _manufacturers.Any() ? _manufacturers.Max(m => m.Id) + 1 : 1;
            manufacturer.Id = newId;

            // Voeg toe aan de lijst
            _manufacturers.Add(manufacturer);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(manufacturer);
        }
        public async Task UpdateManufacturer(Manufacturer manufacturer)
        {
            var existingManufacturer = _manufacturers.FirstOrDefault(m => m.Id == manufacturer.Id);
            if (existingManufacturer != null)
            {
                existingManufacturer.Name = manufacturer.Name;
                existingManufacturer.Country = manufacturer.Country;
                existingManufacturer.Description = manufacturer.Description;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteManufacturer(int id)
        {
            var manufacturer = _manufacturers.FirstOrDefault(m => m.Id == id);
            if (manufacturer != null)
            {
                _manufacturers.Remove(manufacturer);
            }
            await Task.CompletedTask;
        }
    }
}
