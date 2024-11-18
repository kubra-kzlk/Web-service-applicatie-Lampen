using lampen.Models;

namespace lampen.Services
{
    public class ManufacturerService: IManufacturerData
    {
        private readonly List<Manufacturer> _manufacturers = new()
        {
            new Manufacturer { Id = 1, Naam = "Philips", Land = "Nederland", Beschrijving = "Wereldwijd leider in verlichtingsoplossingen." },
            new Manufacturer { Id = 2, Naam = "IKEA", Land = "Zweden", Beschrijving = "Bekend om betaalbare en stijlvolle woningdecoratie." }
        };

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await Task.FromResult(_manufacturers);
        }

        public async Task<Manufacturer?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_manufacturers.FirstOrDefault(m => m.Id == id));
        }
        public async Task<Manufacturer> AddAsync(Manufacturer manufacturer)
        {
            // Genereer een nieuw ID
            var newId = _manufacturers.Any() ? _manufacturers.Max(m => m.Id) + 1 : 1;
            manufacturer.Id = newId;

            // Voeg toe aan de lijst
            _manufacturers.Add(manufacturer);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(manufacturer);
        }
    }
}
