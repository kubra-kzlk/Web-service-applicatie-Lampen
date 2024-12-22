using Microsoft.EntityFrameworkCore;
using lampen.Models;
using lampen.Data;

namespace lampen.Services
{
    public class LampServiceDb : ILampData
    {
        private readonly DatabaseContext _context;

        public LampServiceDb(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Lamp>> GetAllLamps()
        {
            return await _context.Lamps.ToListAsync();
        }

        public async Task<Lamp?> GetLampById(int id)
        {
            return await _context.Lamps.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Lamp> CreateLamp(Lamp newLamp)
        {
            _context.Lamps.Add(newLamp);
            await _context.SaveChangesAsync();
            return newLamp;
        }

        public async Task UpdateLamp(Lamp newLamp)
        {
            _context.Lamps.Update(newLamp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLamp(int id)
        {
            var lampToDelete = await _context.Lamps.FirstOrDefaultAsync(l => l.Id == id);
            if (lampToDelete != null)
            {
                _context.Lamps.Remove(lampToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
