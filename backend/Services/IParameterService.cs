using CaLabApi.Models;

namespace CaLabApi.Services
{
    public interface IParameterService
    {
        Task<PagedResult<McaParameter>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null);
        Task<McaParameter?> GetByIdAsync(int id);
        Task<McaParameter> CreateAsync(McaParameter parameter);
        Task<McaParameter?> UpdateAsync(int id, McaParameter parameter);
        Task<bool> DeleteAsync(int id);
    }
}