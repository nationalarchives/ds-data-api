using AutoMapper;
using meta_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.PreparedFile;
using TNA.DataDefinitionObjects;

namespace meta_data_api.Controllers;

[Produces("application/json")]
[Route("preparedfile")]
public class PreparedFileController : Controller
{
    private IPreparedFileContext _dataContext;
    private readonly IMapper _mapper;
    private ILogger<PreparedFileController> _logger;

    public PreparedFileController(IPreparedFileContext dataContext, IMapper mapper, ILogger<PreparedFileController> logger)
    {
        _dataContext = dataContext;
        _mapper = mapper;
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
        return Ok(_mapper.Map<PreparedFileModel>(prepFile));
    }

    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpsertAsync([FromBody] PreparedFileModel model)
    {
        if (model == null) return BadRequest("PreparedFile object is NULL.");
        if (string.IsNullOrEmpty(model.IAID)) return BadRequest("Iaid is required.");
        var prepFile = _mapper.Map<PrepFile>(model);
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