using DeLaSur.Backend.Application.Commands.TarifaMateriaPrima.Save;
using DeLaSur.Backend.Application.Queries.Usuario.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaMateriaPrimaController : ControllerBase
    {
        private readonly IMediator mediator;
        public TarifaMateriaPrimaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetUsuarioQuery());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var response = await mediator.Send(new SaveTarifaMateriaPrimaCommand());
            return Ok(response);
        }
    }
}
