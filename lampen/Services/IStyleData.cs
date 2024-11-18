using lampen.Models;

namespace lampen.Services
{
    public interface IStyleData
    {
        Task<List<Style>> GetAllAsync();
        Task<Style?> GetByIdAsync(int id);
        Task<Style> AddAsync(Style style);
    }
}
