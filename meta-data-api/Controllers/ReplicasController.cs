using AutoMapper;
using meta_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Replica;
using TNA.DataDefinitionObjects;

namespace meta_data_api.Controllers;

[Produces("application/json")]
[Route("replicas")]
public class ReplicasController : Controller
{
    private IReplicaContext _dataContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ReplicasController> _logger;

    public ReplicasController(IReplicaContext dataContext, IMapper mapper, ILogger<ReplicasController> logger)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: Replicas
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_mapper.Map<IEnumerable<ReplicaModel>>(_dataContext.Get()));
    }

    // GET: Replicas/0ed43461-2ec8-4daa-bc4e-729f05048fec
    [HttpGet("{rid}", Name = "GetRep")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(string rid)
    {
        var replica = await _dataContext.GetAsync(rid);
        if (replica == null) return NotFound();
        return Ok(_mapper.Map<ReplicaModel>(replica));
    }

    // POST: Replicas
    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Upsert([FromBody] ReplicaModel replica)
    {
        if (replica == null) return BadRequest("Replica object is NULL.");
        if (string.IsNullOrEmpty(replica.ReplicaId)) return BadRequest("ReplicaId is required.");
        var repl = _mapper.Map<Repl>(replica);
        await _dataContext.UpsertAsync(repl);
        return CreatedAtRoute("GetRep", new { rid = replica.ReplicaId }, replica);
    }

    /// <response code="200">OK</response>
    /// <response code="400">Bad request</response>
    // DELETE: Replicas/0ed43461-2ec8-4daa-bc4e-729f05048fec
    [HttpDelete("{rid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Delete(string rid)
    {
        if (string.IsNullOrEmpty(rid)) return BadRequest("ReplicaId is required.");

        return await _dataContext.DeleteAsync(rid) ? (IActionResult)NoContent() : BadRequest();
    }
}