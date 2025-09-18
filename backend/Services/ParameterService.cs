using Microsoft.EntityFrameworkCore;
using CaLabApi.Data;
using CaLabApi.Models;

namespace CaLabApi.Services
{
    public class ParameterService : IParameterService
    {
        private readonly CaLabDbContext _context;

        public ParameterService(CaLabDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<McaParameter>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            var query = _context.McaParameters.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Code!.Contains(search) || p.Description!.Contains(search));
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<McaParameter>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<McaParameter?> GetByIdAsync(int id)
        {
            return await _context.McaParameters.FindAsync(id);
        }

        public async Task<McaParameter> CreateAsync(McaParameter parameter)
        {
            parameter.CreatedOn = DateTime.UtcNow;
            _context.McaParameters.Add(parameter);
            await _context.SaveChangesAsync();
            return parameter;
        }

        public async Task<McaParameter?> UpdateAsync(int id, McaParameter parameter)
        {
            var existing = await _context.McaParameters.FindAsync(id);
            if (existing == null) return null;

            existing.Code = parameter.Code;
            existing.Description = parameter.Description;
            existing.IsActive = parameter.IsActive;
            existing.LastUpdatedBy = parameter.LastUpdatedBy;
            existing.LastUpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parameter = await _context.McaParameters.FindAsync(id);
            if (parameter == null) return false;

            _context.McaParameters.Remove(parameter);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}