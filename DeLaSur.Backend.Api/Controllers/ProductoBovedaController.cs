using DeLaSur.Backend.Application.Commands.ProductoBoveda.Insert;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoBovedaController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductoBovedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] InsertProductoBovedaCommand command)
        {
            command.UsuarioCreacion = 1;
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
