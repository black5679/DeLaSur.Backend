using DeLaSur.Backend.Application.Queries.TipoMovimiento.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly IMediator mediator;
        public TipoMovimientoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetTipoMovimientoQuery());
            return Ok(response);
        }
    }
}
