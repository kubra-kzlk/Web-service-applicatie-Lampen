using lampen.Models;

namespace lampen.Services
{
    public class InMemoryLampData : ILampData
    {
        private readonly List<Lamp> _lampen = new()
        {
           new Lamp{
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

        public async Task<Lamp> CreateLamp(Lamp newLamp)
        {
            // Genereer een nieuw ID voor de lamp
            var newId = _lampen.Any() ? _lampen.Max(l => l.Id) + 1 : 1;
            newLamp.Id = newId;

            // Voeg de lamp toe aan de lijst
            _lampen.Add(newLamp);

            // Simuleer een asynchrone operatie
            return await Task.FromResult(newLamp);
        }

        public async Task UpdateLamp(Lamp newLamp)
        {
            var lampToUpdate = _lampen.FirstOrDefault(l => l.Id == newLamp.Id);
            if (lampToUpdate != null)
            {
                lampToUpdate.Name = newLamp.Name;
                lampToUpdate.Description = newLamp.Description;
                lampToUpdate.Price = newLamp.Price;
                lampToUpdate.IsActive = newLamp.IsActive;
                lampToUpdate.Date = newLamp.Date;
                lampToUpdate.Photo = newLamp.Photo;
                lampToUpdate.Color = newLamp.Color;
                lampToUpdate.ManufacturerId = newLamp.ManufacturerId;
                lampToUpdate.StyleIds = newLamp.StyleIds;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteLamp(int id)
        {
            var lampToDelete = _lampen.FirstOrDefault(l => l.Id == id); // Find the lamp to delete obv id

            if (lampToDelete != null)
            {
                _lampen.Remove(lampToDelete);
            }
            await Task.CompletedTask;
        }
    }
}
