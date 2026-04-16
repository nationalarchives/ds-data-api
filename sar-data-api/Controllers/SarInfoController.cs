using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.SarInfo;
using sar_data_api.Models;

namespace sar_data_api.Controllers
{
    [Produces("application/json")]
    [Route("sarinfo")]
    public class SarInfoController : Controller
    {
        private ILogger<SarInfoController> _logger;
        private ISarContext _dataContext;
        private IClosureCriterionsContext _closureContext;

        public SarInfoController(ILogger<SarInfoController> logger, ISarContext sarContext, IClosureCriterionsContext closureCriterionsContext)
        {
            _logger = logger;
            _dataContext = sarContext;
            _closureContext = closureCriterionsContext;
        }

        [HttpGet("{iaid}", Name = "getsar")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAsync(string iaid)
        {
            if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");
            var record = await _dataContext.GetAsync(iaid);
            if (record == null) return NotFound();
            var closureCriterions = _closureContext.GetAll();
            var result = record.ToSarInfoDisplayModel(closureCriterions);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpsertAsync([FromBody] SarInfoModel model)
        {
            if (model == null) return BadRequest("Sar object is NULL.");
            if (string.IsNullOrEmpty(model.Iaid)) return BadRequest("Iaid is required.");
            var record = model.ToSar();
            await _dataContext.UpsertAsync(record);
            return CreatedAtRoute("getsar", new { iaid = model.Iaid });
        }

        [HttpDelete("{iaid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAsync(string iaid)
        {
            if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");

            return await _dataContext.DeleteAsync(iaid) ? NoContent() : BadRequest();
        }
    }
}
