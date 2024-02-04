using DeLaSur.Backend.Application.Queries.TipoMateriaPrima.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMateriaPrimaController : ControllerBase
    {
        private readonly IMediator mediator;
        public TipoMateriaPrimaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetTipoMateriaPrimaQuery());
            return Ok(response);
        }
    }
}
