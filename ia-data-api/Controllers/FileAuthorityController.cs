using AutoMapper;
using ia_data_api.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.FAInformationAsset;
using TNA.DataDefinitionObjects;

namespace ia_data_api.Controllers;

[Produces("application/json")]
[Route("fileauthority")]
public class FileAuthorityController : Controller
{
    private readonly IFaInformationAssetContext _dataContext;
    private readonly IMapper _mapper;
    private ILogger<FileAuthorityController> _logger;

    public FileAuthorityController(IFaInformationAssetContext dataContext, IMapper mapper, ILogger<FileAuthorityController> logger)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("{faid}", Name = "getasset")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAsync(string faid)
    {
        if (string.IsNullOrEmpty(faid)) return BadRequest("Faid is required.");
        var fileAuthority = await _dataContext.GetAsync(faid);
        if (fileAuthority == null) return NotFound();
        return Ok(_mapper.Map<FaInformationAssetModel>(fileAuthority));
    }

    [HttpPost]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpsertAsync([FromBody] FaInformationAssetModel model)
    {
        if (model == null) return BadRequest("FAInformationAsset object is NULL.");
        if (string.IsNullOrEmpty(model.FaId)) return BadRequest("Faid is required.");
        var fileAuthority = _mapper.Map<FileAuthorityIA>(model);
        await _dataContext.UpsertAsync(fileAuthority);
        return CreatedAtRoute("getasset", new { faid = model.FaId }, model);
    }

    [HttpDelete("{faid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteAsync(string faid)
    {
        if (string.IsNullOrEmpty(faid)) return BadRequest("Faid is required.");

        return await _dataContext.DeleteAsync(faid) ? (IActionResult)NoContent() : BadRequest();
    }
}