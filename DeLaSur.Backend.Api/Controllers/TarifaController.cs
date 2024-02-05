using DeLaSur.Backend.Application.Commands.Tarifa.Save;
using DeLaSur.Backend.Application.Queries.Tarifa.Get;
using DeLaSur.Backend.Application.Queries.Tarifa.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        private readonly IMediator mediator;
        public TarifaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetTarifaQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTarifaQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var response = await mediator.Send(new SaveTarifaCommand());
            return Ok(response);
        }
    }
}
