using Microsoft.AspNetCore.Mvc;
using CaLabApi.Models;
using CaLabApi.Services;

namespace CaLabApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysesController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysesController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<McaAnalysis>>> GetAll(
            int pageNumber = 1, 
            int pageSize = 10, 
            string? search = null)
        {
            var result = await _analysisService.GetAllAsync(pageNumber, pageSize, search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<McaAnalysis>> GetById(int id)
        {
            var analysis = await _analysisService.GetByIdAsync(id);
            if (analysis == null)
            {
                return NotFound();
            }
            return Ok(analysis);
        }

        [HttpPost]
        public async Task<ActionResult<McaAnalysis>> Create(McaAnalysis analysis)
        {
            var createdAnalysis = await _analysisService.CreateAsync(analysis);
            return CreatedAtAction(nameof(GetById), new { id = createdAnalysis.Id }, createdAnalysis);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<McaAnalysis>> Update(int id, McaAnalysis analysis)
        {
            var updatedAnalysis = await _analysisService.UpdateAsync(id, analysis);
            if (updatedAnalysis == null)
            {
                return NotFound();
            }
            return Ok(updatedAnalysis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _analysisService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
