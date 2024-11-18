using lampen.Models;

namespace lampen.Services
{
    public class InMemoryLampData : ILampData
    {
        private readonly List<Lamp> _lampen = new()
        {
            new Lamp
            {
                Id = 1,
                Naam = "Edison Bulb",
                Beschrijving = "Een vintage lamp met een warme gloed.",
                Prijs = 29.99m,
                Actief = true,
                Datum = "2024-01-10",
                Foto = "edison_bulb.jpg",
                Kleur = "Goud",
                FabrikantId = 1,
                StijlIds = new List<int> { 3 }
            },
            new Lamp
            {
                Id = 2,
                Naam = "Arc Lamp",
                Beschrijving = "Een moderne booglamp met een strakke afwerking.",
                Prijs = 199.99m,
                Actief = true,
                Datum = "2023-11-20",
                Foto = "arc_lamp.jpg",
                Kleur = "Zilver",
                FabrikantId = 2,
                StijlIds = new List<int> { 1 }
            }
        };
        public async Task<List<Lamp>> GetAllAsync()
        {
            return await Task.FromResult(_lampen);
        }

        public async Task<Lamp?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_lampen.FirstOrDefault(l => l.Id == id));
        }

        public async Task<Lamp> AddAsync(Lamp lamp)
        {
            // Genereer een nieuw ID voor de lamp
            var newId = _lampen.Any() ? _lampen.Max(l => l.Id) + 1 : 1;
            lamp.Id = newId;

            // Voeg de lamp toe aan de lijst
            _lampen.Add(lamp);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(lamp);
        }
    }
}
