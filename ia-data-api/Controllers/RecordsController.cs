using ia_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.InformationAsset;

namespace ia_data_api.Controllers;

[Produces("application/json")]
[Route("records")]
public class RecordsController : Controller
{
    private IInformationAssetContext _dataContext;
    private readonly ILogger<RecordsController> _logger;

    public RecordsController(IInformationAssetContext dataContext, ILogger<RecordsController> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    [HttpGet("{iaid}", Name = "getrecord")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAsync(string iaid)
    {
        if (string.IsNullOrEmpty(iaid)) return BadRequest("Iaid is required.");
        var record = await _dataContext.GetAsync(iaid);
        if (record == null) return NotFound();
        return Ok(record.ToInformationAssetModel());
    }

    [HttpGet("byref", Name = "getrecordsbyref")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetRecordsByRefAsync(string reference)
    {
        if (string.IsNullOrEmpty(reference)) return BadRequest("Catalogue reference is required.");
        var records = await _dataContext.GetAsyncByRef(reference);
        if (records == null) return NotFound();
        return Ok(records.Select(x => x.ToInformationAssetModel()).ToList());
    }

    [HttpGet("byreplicaid/{rid}", Name = "getreplicarecords")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetSomeRecords(string rid)
    {
        if (string.IsNullOrEmpty(rid)) return BadRequest("Replica ID is required.");
        var records = await _dataContext.GetAsyncByRid(rid);
        if (records == null) return NotFound();
        return Ok(records.Select(x => x.ToInformationAssetModel()).ToList());
    }

    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpsertAsync([FromBody]InformationAssetModel model)
    {
        if (model == null) return BadRequest("InformationAsset object is NULL.");
        if (string.IsNullOrEmpty(model.Iaid)) return BadRequest("Iaid is required.");
        var record = model.ToIA();
        await _dataContext.UpsertAsync(record);
        return CreatedAtRoute("getrecord", new { iaid = model.Iaid }, model);
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