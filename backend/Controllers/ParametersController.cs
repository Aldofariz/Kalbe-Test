using Microsoft.AspNetCore.Mvc;
using CaLabApi.Models;
using CaLabApi.Services;

namespace CaLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : ControllerBase
    {
        private readonly IParameterService _parameterService;

        public ParametersController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<McaParameter>>> GetAll(
            int pageNumber = 1, 
            int pageSize = 10, 
            string? search = null)
        {
            var result = await _parameterService.GetAllAsync(pageNumber, pageSize, search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<McaParameter>> GetById(int id)
        {
            var parameter = await _parameterService.GetByIdAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            return Ok(parameter);
        }

        [HttpPost]
        public async Task<ActionResult<McaParameter>> Create(McaParameter parameter)
        {
            var createdParameter = await _parameterService.CreateAsync(parameter);
            return CreatedAtAction(nameof(GetById), new { id = createdParameter.Id }, createdParameter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<McaParameter>> Update(int id, McaParameter parameter)
        {
            var updatedParameter = await _parameterService.UpdateAsync(id, parameter);
            if (updatedParameter == null)
            {
                return NotFound();
            }
            return Ok(updatedParameter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _parameterService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
