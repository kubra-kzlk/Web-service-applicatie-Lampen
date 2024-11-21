using lampen.Models;

namespace lampen.Services
{
    public interface ILampData
    {
        Task<List<Lamp>> GetAllLamps();
        Task<Lamp?> GetLampById(int id);
        Task<Lamp> CreateLamp(Lamp lamp);
        Task UpdateLamp(Lamp lamp);
        Task DeleteLamp(int id);
    }
}
