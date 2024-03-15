using DeLaSur.Backend.Application.Commands.Entrada.Insert;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IMediator mediator;
        public EntradaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertEntradaCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
