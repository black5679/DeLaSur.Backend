using DeLaSur.Backend.Application.Commands.MateriaPrimaBoveda.Insert;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaBovedaController : ControllerBase
    {
        private readonly IMediator mediator;
        public MateriaPrimaBovedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] InsertMateriaPrimaBovedaCommand command)
        {
            command.UsuarioCreacion = 1;
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
