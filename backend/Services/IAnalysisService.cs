using CaLabApi.Models;

namespace CaLabApi.Services
{
    public interface IAnalysisService
    {
        Task<PagedResult<McaAnalysis>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null);
        Task<McaAnalysis?> GetByIdAsync(int id);
        Task<McaAnalysis> CreateAsync(McaAnalysis analysis);
        Task<McaAnalysis?> UpdateAsync(int id, McaAnalysis analysis);
        Task<bool> DeleteAsync(int id);
    }
}