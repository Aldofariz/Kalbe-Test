using Microsoft.EntityFrameworkCore;
using CaLabApi.Data;
using CaLabApi.Models;

namespace CaLabApi.Services
{
    public class MethodService : IMethodService
    {
        private readonly CaLabDbContext _context;

        public MethodService(CaLabDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<McaMethod>> GetAllAsync(int pageNumber = 1, int pageSize = 10, string? search = null)
        {
            var query = _context.McaMethods.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Code!.Contains(search) || m.Description!.Contains(search));
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<McaMethod>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<McaMethod?> GetByIdAsync(int id)
        {
            return await _context.McaMethods.FindAsync(id);
        }

        public async Task<McaMethod> CreateAsync(McaMethod method)
        {
            method.CreatedOn = DateTime.UtcNow;
            _context.McaMethods.Add(method);
            await _context.SaveChangesAsync();
            return method;
        }

        public async Task<McaMethod?> UpdateAsync(int id, McaMethod method)
        {
            var existing = await _context.McaMethods.FindAsync(id);
            if (existing == null) return null;

            existing.Code = method.Code;
            existing.Description = method.Description;
            existing.IsActive = method.IsActive;
            existing.LastUpdatedBy = method.LastUpdatedBy;
            existing.LastUpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var method = await _context.McaMethods.FindAsync(id);
            if (method == null) return false;

            _context.McaMethods.Remove(method);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}