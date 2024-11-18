using lampen.Models;

namespace lampen.Services
{
    public class ManufacturerService: IManufacturerData
    {
        private readonly List<Manufacturer> _fabrikanten = new()
        {
            new Manufacturer { Id = 1, Naam = "Philips", Land = "Nederland", Beschrijving = "Wereldwijd leider in verlichtingsoplossingen." },
            new Manufacturer { Id = 2, Naam = "IKEA", Land = "Zweden", Beschrijving = "Bekend om betaalbare en stijlvolle woningdecoratie." }
        };

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await Task.FromResult(_fabrikanten);
        }

        public async Task<Manufacturer?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_fabrikanten.FirstOrDefault(m => m.Id == id));
        }
    }
}
