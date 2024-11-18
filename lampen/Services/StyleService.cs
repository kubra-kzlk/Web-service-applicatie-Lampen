using lampen.Models;

namespace lampen.Services
{
    public class StyleService : IStyleData
    {
        private readonly List<Style> _stijlen = new()
        {
            new Style { Id = 1, Naam = "Modern", Beschrijving = "Minimalistisch en strak ontwerp." },
            new Style { Id = 2, Naam = "Industrieel", Beschrijving = "Ruig en robuust met metalen accenten." },
            new Style { Id = 3, Naam = "Vintage", Beschrijving = "Geïnspireerd op klassieke ontwerpen uit het verleden." }
        };

        public async Task<List<Style>> GetAllAsync()
        {
            return await Task.FromResult(_stijlen);
        }

        public async Task<Style?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_stijlen.FirstOrDefault(s => s.Id == id));
        }
    }
}
