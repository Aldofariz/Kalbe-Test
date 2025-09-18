using CaLabApi.Models;

namespace CaLabApi.Services
{
    public interface ISampleTypeService
    {
        Task<PagedResult<McaSampleType>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null);
        Task<McaSampleType?> GetByIdAsync(int id);
        Task<McaSampleType> CreateAsync(McaSampleType sampleType);
        Task<McaSampleType?> UpdateAsync(int id, McaSampleType sampleType);
        Task<bool> DeleteAsync(int id);
    }
}