using CaLabApi.Models;

namespace CaLabApi.Services
{
    public interface IMethodService
    {
        Task<PagedResult<McaMethod>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null);
        Task<McaMethod?> GetByIdAsync(int id);
        Task<McaMethod> CreateAsync(McaMethod method);
        Task<McaMethod?> UpdateAsync(int id, McaMethod method);
        Task<bool> DeleteAsync(int id);
    }
}