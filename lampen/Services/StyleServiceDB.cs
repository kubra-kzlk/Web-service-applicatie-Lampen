using Microsoft.EntityFrameworkCore;
using lampen.Data;
using lampen.Models;

namespace lampen.Services
{
    public class StyleServiceDb : IStyleData
    {
        private readonly DatabaseContext _context;

        public StyleServiceDb(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Style>> GetAllStyles()
        {
            return await _context.Styles.ToListAsync();
        }

        public async Task<Style?> GetStyleById(int id)
        {
            return await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Style> CreateStyle(Style style)
        {
            _context.Styles.Add(style);
            await _context.SaveChangesAsync();
            return style;
        }

        public async Task UpdateStyle(Style style)
        {
            var existingStyle = await _context.Styles.FirstOrDefaultAsync(s => s.Id == style.Id);
            if (existingStyle != null)
            {
                existingStyle.Name = style.Name;
                existingStyle.Description = style.Description;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStyle(int id)
        {
            var style = await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);
            if (style != null)
            {
                _context.Styles.Remove(style);
                await _context.SaveChangesAsync();
            }
        }
    }
}
