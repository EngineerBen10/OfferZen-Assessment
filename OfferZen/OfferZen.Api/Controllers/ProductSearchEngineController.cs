using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfferZen.Application.Commands.ProductCommands;
using OfferZen.Application.Queries;
using OfferZen.Application.Queries.ProductQueries;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Api.Controllers;


[Route("api/products/search")]
[ApiController]
public class ProductSearchEngineController(ISender sender) : ControllerBase
{


    [HttpGet("")]
    public async Task<IActionResult> GetProductsSearchEngineAsync([FromBody] ProductQueryDto productQueryDto)
    {
        var result = await sender.Send(new GetProductsSearchEngineQuery(productQueryDto));

        return Ok(result);
    }
  
    
}