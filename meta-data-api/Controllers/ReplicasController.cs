using meta_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Replica;

namespace meta_data_api.Controllers;

[Produces("application/json")]
[Route("replicas")]
public class ReplicasController : Controller
{
    private IReplicaContext _dataContext;
    private readonly ILogger<ReplicasController> _logger;

    public ReplicasController(IReplicaContext dataContext, ILogger<ReplicasController> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    // GET: Replicas
    [HttpGet]
    public IActionResult Get()
    {
        var replicas = _dataContext.Get().Select(x => x.ToReplicaModel()).ToList();
        return Ok(replicas);
    }

    // GET: Replicas/0ed43461-2ec8-4daa-bc4e-729f05048fec
    [HttpGet("{rid}", Name = "GetRep")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(string rid)
    {
        var replica = await _dataContext.GetAsync(rid);
        if (replica == null) return NotFound();
        return Ok(replica.ToReplicaModel());
    }

    // POST: Replicas
    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Upsert([FromBody] ReplicaModel replica)
    {
        if (replica == null) return BadRequest("Replica object is NULL.");
        if (string.IsNullOrEmpty(replica.ReplicaId)) return BadRequest("ReplicaId is required.");
        var repl = replica.ToRepl();
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