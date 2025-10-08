using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfferZen.Application.Commands.ProductCommands;
using OfferZen.Application.Queries.ProductQueries;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Api.Controllers;


[Route("api/products")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{

    [HttpPost("")]
    public async Task<IActionResult> AddProductAsync([FromBody] Product product)
    {
          var result = await sender.Send(new AddProductCommand(product));
          
          return Ok(result);
    }

    [HttpPut("")]

    public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
    {
        var result = await sender.Send(new UpdateProductCommand(product));
        
        return Ok(result);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetProductsAsync([FromQuery] ProductQueryDto productQueryDto)
    {
        var result = await sender.Send(new GetProductsQuery(productQueryDto));

        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
    {
        var result = await sender.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));
        
        return Ok(result);
    }
    
}