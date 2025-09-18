using Microsoft.AspNetCore.Mvc;
using CaLabApi.Models;
using CaLabApi.Services;

namespace CaLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MethodsController : ControllerBase
    {
        private readonly IMethodService _methodService;

        public MethodsController(IMethodService methodService)
        {
            _methodService = methodService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<McaMethod>>> GetAll(
            int pageNumber = 1, 
            int pageSize = 10, 
            string? search = null)
        {
            var result = await _methodService.GetAllAsync(pageNumber, pageSize, search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<McaMethod>> GetById(int id)
        {
            var method = await _methodService.GetByIdAsync(id);
            if (method == null)
            {
                return NotFound();
            }
            return Ok(method);
        }

        [HttpPost]
        public async Task<ActionResult<McaMethod>> Create(McaMethod method)
        {
            var createdMethod = await _methodService.CreateAsync(method);
            return CreatedAtAction(nameof(GetById), new { id = createdMethod.Id }, createdMethod);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<McaMethod>> Update(int id, McaMethod method)
        {
            var updatedMethod = await _methodService.UpdateAsync(id, method);
            if (updatedMethod == null)
            {
                return NotFound();
            }
            return Ok(updatedMethod);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _methodService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}