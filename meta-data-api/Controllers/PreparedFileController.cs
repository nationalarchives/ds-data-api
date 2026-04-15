using meta_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.PreparedFile;

namespace meta_data_api.Controllers;

[Produces("application/json")]
[Route("preparedfile")]
public class PreparedFileController : Controller
{
    private IPreparedFileContext _dataContext;
    private ILogger<PreparedFileController> _logger;

    public PreparedFileController(IPreparedFileContext dataContext, ILogger<PreparedFileController> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    [HttpGet("{iaid}", Name = "getpreparedfile")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAsync(string iaid)
    {
        if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");
        var prepFile = await _dataContext.GetAsync(iaid);
        if (prepFile == null) return NotFound();
        return Ok(prepFile.ToPreparedFileModel());
    }

    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpsertAsync([FromBody] PreparedFileModel model)
    {
        if (model == null) return BadRequest("PreparedFile object is NULL.");
        if (string.IsNullOrEmpty(model.IAID)) return BadRequest("Iaid is required.");
        var prepFile = model.ToPrepFile();
        await _dataContext.UpsertAsync(prepFile);
        return CreatedAtRoute("getpreparedfile", new { iaid = model.IAID }, model);
    }

    [HttpDelete("{iaid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteAsync(string iaid)
    {
        if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");

        return await _dataContext.DeleteAsync(iaid) ? (IActionResult)NoContent() : BadRequest();
    }
}