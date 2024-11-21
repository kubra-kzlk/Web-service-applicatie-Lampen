using lampen.Models;

namespace lampen.Services
{
    public interface IStyleData
    {
        Task<List<Style>> GetAllStyles();
        Task<Style?> GetStyleById(int id);
        Task<Style> CreateStyle(Style style);
        Task UpdateStyle(Style style); 
        Task DeleteStyle(int id);
    }
}
