using DeLaSur.Backend.Application.Commands.Compra.Insert;
using DeLaSur.Backend.Application.Commands.Compra.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IMediator mediator;
        public CompraController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertCompraCommand command)
        {
            command.UsuarioCreacion = 1;
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompraCommand command)
        {
            command.UsuarioModificacion = 1;
            command.Id = id;
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
