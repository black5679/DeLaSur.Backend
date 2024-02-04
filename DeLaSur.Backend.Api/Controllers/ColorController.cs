using DeLaSur.Backend.Application.Queries.Color.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator mediator;
        public ColorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetColorQuery());
            return Ok(response);
        }
    }
}
