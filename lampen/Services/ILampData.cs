using lampen.Models;

namespace lampen.Services
{
    public interface ILampData
    {
        Task<List<Lamp>> GetAllAsync();
        Task<Lamp?> GetByIdAsync(int id);
    }
}
