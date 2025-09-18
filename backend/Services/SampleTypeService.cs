using Microsoft.EntityFrameworkCore;
using CaLabApi.Data;
using CaLabApi.Models;

namespace CaLabApi.Services
{
    public class SampleTypeService : ISampleTypeService
    {
        private readonly CaLabDbContext _context;

        public SampleTypeService(CaLabDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<McaSampleType>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            var query = _context.McaSampleTypes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.Code!.Contains(search) || s.Description!.Contains(search));
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<McaSampleType>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<McaSampleType?> GetByIdAsync(int id)
        {
            return await _context.McaSampleTypes.FindAsync(id);
        }

        public async Task<McaSampleType> CreateAsync(McaSampleType sampleType)
        {
            sampleType.CreatedOn = DateTime.UtcNow;
            _context.McaSampleTypes.Add(sampleType);
            await _context.SaveChangesAsync();
            return sampleType;
        }

        public async Task<McaSampleType?> UpdateAsync(int id, McaSampleType sampleType)
        {
            var existing = await _context.McaSampleTypes.FindAsync(id);
            if (existing == null) return null;

            existing.Code = sampleType.Code;
            existing.Description = sampleType.Description;
            existing.IsActive = sampleType.IsActive;
            existing.LastUpdatedBy = sampleType.LastUpdatedBy;
            existing.LastUpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sampleType = await _context.McaSampleTypes.FindAsync(id);
            if (sampleType == null) return false;

            _context.McaSampleTypes.Remove(sampleType);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}