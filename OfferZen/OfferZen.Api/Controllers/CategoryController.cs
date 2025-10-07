using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfferZen.Application.Commands.CategoryCommands;
using OfferZen.Application.Queries.CategoryQueries;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
     [HttpPost("")]

     public async Task<IActionResult> AddCategoryAsync([FromBody] Category category)
     {
          var result = await sender.Send(new AddCategoryCommand(category));
          
          return Ok(result);
     }

    [HttpGet("")]

    public async Task<IActionResult> GetCategoriesAsync()
     {
          var result = await sender.Send(new GetCategoriesQuery());
          
          return Ok(result);
     }
     [HttpGet("tree")]
     public async Task<IActionResult> GetCategoryTreeAsync()
     {
          var result = await sender.Send(new GetCategoryTreeQuery());
          
          return Ok(result);
    }

    // category tree Structure
}