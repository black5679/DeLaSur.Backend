using DeLaSur.Backend.Application.Commands.Boveda.Insert;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BovedaController : ControllerBase
    {
        private readonly IMediator mediator;
        public BovedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertBovedaCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
