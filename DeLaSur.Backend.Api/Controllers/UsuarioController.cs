using DeLaSur.Backend.Application.Commands.Usuario.Insert;
using DeLaSur.Backend.Application.Commands.Usuario.LoginDashboard;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("logindashboard")]
        public async Task<IActionResult> LoginDashboard([FromBody] LoginDashboardUsuarioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(new { Token = response });
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertUsuarioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
