using DeLaSur.Backend.Application.Queries.Movimiento.Get;
using DeLaSur.Backend.Application.Queries.Movimiento.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMediator mediator;
        public MovimientoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetMovimientoQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdMovimientoQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
