using DeLaSur.Backend.Application.Queries.TipoBoveda.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoBovedaController : ControllerBase
    {
        private readonly IMediator mediator;
        public TipoBovedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetTipoBovedaQuery());
            return Ok(response);
        }
    }
}
