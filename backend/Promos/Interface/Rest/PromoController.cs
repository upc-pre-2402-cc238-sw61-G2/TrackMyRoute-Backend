using backend.Promos.Domain.Model.Queries;
using backend.Promos.Domain.Services;
using backend.Promos.Interface.Rest.Resources;
using backend.Promos.Interface.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.Promos.Interface.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class PromoController(IPromoCommandService promoCommandService, IPromoQueryService promoQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePromo([FromBody] CreatePromoResource createPromoResource)
    {
        var createPromoCommand = CreatePromoCommandFromResourceAssembler.ToCommandFromResource(createPromoResource);
        var promo = await promoCommandService.Handle(createPromoCommand);
        if (promo is null) return BadRequest();
        var resource = PromoResourceFromEntityAssembler.ToResourceFromEntity(promo);
        return CreatedAtAction(nameof(GetPromoById), new { promoId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPromos()
    {
        var getAllPromosQuery = new GetAllPromosQuery();
        var promos = await promoQueryService.Handle(new GetAllPromosQuery());
        var resources = promos.Select(PromoResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{promoId:int}")]
    public async Task<IActionResult> GetPromoById([FromRoute] int promoId)
    {
        var promo = await promoQueryService.Handle(new GetPromoByIdQuery(promoId));
        if (promo is null) return BadRequest();
        var resource = PromoResourceFromEntityAssembler.ToResourceFromEntity(promo);
        return Ok(resource);
    }
}