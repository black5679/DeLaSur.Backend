using DeLaSur.Backend.Application.Commands.MateriaPrima.Insert;
using DeLaSur.Backend.Application.Queries.MateriaPrima.Get;
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
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertMateriaPrimaCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetMateriaPrimaQuery());
            return Ok(response);
        }
    }
}
