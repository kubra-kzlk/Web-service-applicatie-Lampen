using lampen.Models;

namespace lampen.Services
{
    public interface IManufacturerData
    {
        Task<List<Manufacturer>> GetAllAsync();
        Task<Manufacturer?> GetByIdAsync(int id);
    }
}
