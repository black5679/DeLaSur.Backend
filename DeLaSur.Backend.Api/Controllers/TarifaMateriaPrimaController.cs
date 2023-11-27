using DeLaSur.Backend.Application.Commands.TarifaMateriaPrima.Save;
using DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.Get;
using DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.GetById;
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
            var response = await mediator.Send(new GetTarifaMateriaPrimaQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTarifaMateriaPrimaQuery query)
        {
            var response = await mediator.Send(query);
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
