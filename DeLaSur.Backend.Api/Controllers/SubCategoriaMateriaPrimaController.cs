using DeLaSur.Backend.Application.Queries.SubCategoriaMateriaPrima.GetByIdCategoriaMateriaPrima;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaMateriaPrimaController : ControllerBase
    {
        private readonly IMediator mediator;
        public SubCategoriaMateriaPrimaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{IdCategoriaMateriaPrima}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
