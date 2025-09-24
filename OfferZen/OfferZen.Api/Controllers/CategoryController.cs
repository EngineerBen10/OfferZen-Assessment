using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfferZen.Application.Commands.CategoryCommands;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
     [HttpPost("")]

     public async Task<IActionResult> AddCategoryAsync([FromBody] Category category)
     {
          var result = await sender.Send(new AddCategoryCommand(category));
          
          return Ok(result);
     }
     
     // category tree Structure
}