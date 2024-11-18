using lampen.Models;

namespace lampen.Services
{
    public class StyleService : IStyleData
    {
        private readonly List<Style> _styles = new()
        {
            new Style { Id = 1, Naam = "Modern", Beschrijving = "Minimalistisch en strak ontwerp." },
            new Style { Id = 2, Naam = "Industrieel", Beschrijving = "Ruig en robuust met metalen accenten." },
            new Style { Id = 3, Naam = "Vintage", Beschrijving = "Geïnspireerd op klassieke ontwerpen uit het verleden." }
        };

        public async Task<List<Style>> GetAllAsync()
        {
            return await Task.FromResult(_styles);
        }

        public async Task<Style?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_styles.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Style> AddAsync(Style style)
        {
            // Genereer een nieuw ID voor de style
            var newId = _styles.Any() ? _styles.Max(s => s.Id) + 1 : 1;
            style.Id = newId;

            // Voeg de style toe aan de lijst
            _styles.Add(style);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(style);
        }
    }
}
