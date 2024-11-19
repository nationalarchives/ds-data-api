using AutoMapper;
using meta_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.ReplicaEditSet;
using TNA.DataDefinitionObjects;

namespace meta_data_api.Controllers;

[Produces("application/json")]
[Route("replicaeditset")]
public class ReplicaEditSetController : Controller
{
    private IReplicaEditSetContext _dataContext;
    private readonly IMapper _mapper;
    private ILogger<ReplicaEditSetController> _logger;

    public ReplicaEditSetController(IReplicaEditSetContext dataContext, IMapper mapper, ILogger<ReplicaEditSetController> logger)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("{iaid}", Name = "getreplicaeditset")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAsync(string iaid)
    {
        if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");
        var replicaEditSet = await _dataContext.GetAsync(iaid);
        if (replicaEditSet == null) return NotFound();
        return Ok(_mapper.Map<ReplicaEditSetModel>(replicaEditSet));
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpsertAsync([FromBody] ReplicaEditSetModel model)
    {
        if (model == null) return BadRequest("ReplicaEditSet object is NULL.");
        if (string.IsNullOrEmpty(model.IAID)) return BadRequest("Iaid is required.");
        var replicaEditSet = _mapper.Map<ReplEditSet>(model);
        return await _dataContext.UpsertAsync(replicaEditSet) ? (IActionResult)NoContent() : BadRequest();
    }

    [HttpDelete("{iaid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteAsync(string iaid)
    {
        if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");

        return await _dataContext.DeleteAsync(iaid) ? (IActionResult)NoContent() : BadRequest();
    }

    [HttpGet]
    [Route("count")]
    public async Task<IActionResult> GetCountAsync()
    {
        return Ok(await _dataContext.CountAsync());
    }

    [HttpGet]
    [Route("size/{pageSize}/page/{pageNumber}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetReplicaEditSetAsync(int pageSize, int pageNumber)
    {
        if (pageSize < 1 || pageNumber < 1) return BadRequest("Page size and/or number should be grater than 0.");
        var replicaEditSet = await _dataContext.GetAsync(pageSize, pageNumber);
        if (replicaEditSet == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<ReplicaEditSetModel>>(replicaEditSet));
    }
}