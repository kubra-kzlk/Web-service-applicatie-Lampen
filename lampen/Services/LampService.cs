using lampen.Models;

namespace lampen.Services
{
    public class LampService : ILampData
    {
        private readonly List<Lamp> _lampen = new()
        {
            new Lamp
            {
                Id = 1,
                Name = "Edison Bulb",
                Description = "A vintage lamp with a warm glow.",
                Price = 29.99m,
                IsActive = true,
                Date = "2024-01-10",
                Photo = "edison_bulb.jpg",
                Color = "Gold",
                ManufacturerId = 1,
                StyleIds = new List<int> { 3 }
            },
            new Lamp
            {
                Id = 2,
                Name = "Arc Lamp",
                Description = "A modern arc lamp with a sleek finish.",
                Price = 199.99m,
                IsActive = true,
                Date = "2023-11-20",
                Photo = "arc_lamp.jpg",
                Color = "Silver",
                ManufacturerId = 2,
                StyleIds = new List<int> { 1 }
            }
        };

        public async Task<List<Lamp>> GetAllLamps()
        {
            return await Task.FromResult(_lampen);
        }

        public async Task<Lamp?> GetLampById(int id)
        {
            return await Task.FromResult(_lampen.FirstOrDefault(l => l.Id == id));
        }
        public async Task<Lamp> CreateLamp(Lamp lamp) // Implementeert de nieuwe methode
        {
            // Genereer een nieuw ID voor de lamp
            var newId = _lampen.Any() ? _lampen.Max(l => l.Id) + 1 : 1;
            lamp.Id = newId;

            // Voeg de lamp toe aan de lijst
            _lampen.Add(lamp);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(lamp);
        }

        public async Task DeleteLamp(int id)
        {
            var lamp = _lampen.FirstOrDefault(l => l.Id == id);
            if (lamp != null)
            {
                _lampen.Remove(lamp);
            }
            await Task.CompletedTask;
        }

       public async Task UpdateLamp(Lamp lamp)
        {
            var existingLamp = _lampen.FirstOrDefault(l => l.Id == lamp.Id);
            if (existingLamp != null)
            {
                existingLamp.Name = lamp.Name;
                existingLamp.Description = lamp.Description;
                existingLamp.Price = lamp.Price;
                existingLamp.IsActive = lamp.IsActive;
                existingLamp.Date = lamp.Date;
                existingLamp.Photo = lamp.Photo;
                existingLamp.Color = lamp.Color;
                existingLamp.ManufacturerId = lamp.ManufacturerId;
                existingLamp.StyleIds = lamp.StyleIds;
            }
            await Task.CompletedTask;
        }
    }

}

