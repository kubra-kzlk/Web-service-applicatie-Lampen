using lampen.Models;

namespace lampen.Services
{
    public class StyleService : IStyleData
    {
        private readonly List<Style> _styles = new()
        {
            new Style { Id = 1, Name = "Modern", Description = "Minimalist and sleek design." },
            new Style { Id = 2, Name = "Industrial", Description = "Rough and robust with metal accents." },
            new Style { Id = 3, Name = "Vintage", Description = "Inspired by classic designs from the past." }
        };

        public async Task<List<Style>> GetAllStyles()
        {
            return await Task.FromResult(_styles);
        }

        public async Task<Style?> GetStyleById(int id)
        {
            return await Task.FromResult(_styles.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Style> CreateStyle(Style style)
        {
            // Genereer een nieuw ID voor de style
            var newId = _styles.Any() ? _styles.Max(s => s.Id) + 1 : 1;
            style.Id = newId;

            // Voeg de style toe aan de lijst
            _styles.Add(style);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(style);
        }
        public async Task UpdateStyle(Style style)
        {
            var existingStyle = _styles.FirstOrDefault(s => s.Id == style.Id);
            if (existingStyle != null)
            {
                existingStyle.Name = style.Name;
                existingStyle.Description = style.Description;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteStyle(int id)
        {
            var style = _styles.FirstOrDefault(s => s.Id == id);
            if (style != null)
            {
                _styles.Remove(style);
            }
            await Task.CompletedTask;
        }
    }
}
