using DeLaSur.Backend.Application.Queries.MateriaPrima.Get;
using DeLaSur.Backend.Application.Queries.MateriaPrima.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
        private readonly IMediator mediator;
        public MateriaPrimaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetMateriaPrimaQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdMateriaPrimaQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
