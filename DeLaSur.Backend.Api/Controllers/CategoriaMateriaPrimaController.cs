using DeLaSur.Backend.Application.Queries.CategoriaMateriaPrima.GetByIdTipoMateriaPrima;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaMateriaPrimaController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriaMateriaPrimaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{IdTipoMateriaPrima}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
