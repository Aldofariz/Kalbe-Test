using Microsoft.EntityFrameworkCore;
using CaLabApi.Data;
using CaLabApi.Models;

namespace CaLabApi.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly CaLabDbContext _context;

        public AnalysisService(CaLabDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<McaAnalysis>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            var query = _context.McaAnalyses.Include(a => a.Method).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Code!.Contains(search) || a.Description!.Contains(search));
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<McaAnalysis>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<McaAnalysis?> GetByIdAsync(int id)
        {
            return await _context.McaAnalyses
                .Include(a => a.Method)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<McaAnalysis> CreateAsync(McaAnalysis analysis)
        {
            analysis.CreatedOn = DateTime.UtcNow;
            _context.McaAnalyses.Add(analysis);
            await _context.SaveChangesAsync();
            return analysis;
        }

        public async Task<McaAnalysis?> UpdateAsync(int id, McaAnalysis analysis)
        {
            var existing = await _context.McaAnalyses.FindAsync(id);
            if (existing == null) return null;

            existing.Code = analysis.Code;
            existing.Description = analysis.Description;
            existing.IsActive = analysis.IsActive;
            existing.Method = analysis.Method;
            existing.ParameterId = analysis.ParameterId;
            existing.SampleTypeId = analysis.SampleTypeId;
            existing.LeadTime = analysis.LeadTime;
            existing.LastUpdatedBy = analysis.LastUpdatedBy;
            existing.LastUpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var analysis = await _context.McaAnalyses.FindAsync(id);
            if (analysis == null) return false;

            _context.McaAnalyses.Remove(analysis);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}