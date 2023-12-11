using DeLaSur.Backend.Application.Commands.Material.Insert;
using DeLaSur.Backend.Application.Queries.Material.Get;
using DeLaSur.Backend.Application.Queries.Material.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMediator mediator;
        public MaterialController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetMaterialQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdMaterialQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] InsertMaterialCommand command)
        {
            command.UsuarioCreacion = 1;
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
