using Microsoft.AspNetCore.Mvc;
using CaLabApi.Models;
using CaLabApi.Services;

namespace CaLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleTypesController : ControllerBase
    {
        private readonly ISampleTypeService _sampleTypeService;

        public SampleTypesController(ISampleTypeService sampleTypeService)
        {
            _sampleTypeService = sampleTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<McaSampleType>>> GetAll(
            int pageNumber = 1, 
            int pageSize = 10, 
            string? search = null)
        {
            var result = await _sampleTypeService.GetAllAsync(pageNumber, pageSize, search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<McaSampleType>> GetById(int id)
        {
            var sampleType = await _sampleTypeService.GetByIdAsync(id);
            if (sampleType == null)
            {
                return NotFound();
            }
            return Ok(sampleType);
        }

        [HttpPost]
        public async Task<ActionResult<McaSampleType>> Create(McaSampleType sampleType)
        {
            var createdSampleType = await _sampleTypeService.CreateAsync(sampleType);
            return CreatedAtAction(nameof(GetById), new { id = createdSampleType.Id }, createdSampleType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<McaSampleType>> Update(int id, McaSampleType sampleType)
        {
            var updatedSampleType = await _sampleTypeService.UpdateAsync(id, sampleType);
            if (updatedSampleType == null)
            {
                return NotFound();
            }
            return Ok(updatedSampleType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sampleTypeService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
