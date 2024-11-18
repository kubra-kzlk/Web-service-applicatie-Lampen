using lampen.Models;

namespace lampen.Services
{
    public class StyleService
    {
        private readonly List<Style> _stijlen = new()
        {
            new Style { Id = 1, Naam = "Modern", Beschrijving = "Minimalistisch en strak ontwerp." },
            new Style { Id = 2, Naam = "Industrieel", Beschrijving = "Ruig en robuust met metalen accenten." },
            new Style { Id = 3, Naam = "Vintage", Beschrijving = "Geïnspireerd op klassieke ontwerpen uit het verleden." }
        };

        public List<Style> GetAll() => _stijlen;

        public Style? GetById(int id) => _stijlen.FirstOrDefault(s => s.Id == id);

    }
}
