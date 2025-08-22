using BusinessLayer.CQRS.Commands.Compra;
using BusinessLayer.CQRS.Queries.Compra;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CompraController(IMediator mediator) => _mediator = mediator; 

        [HttpPost]
        [Route("RegistrarCompra")]
        public async Task<IActionResult> RegistrarCompra([FromBody] CompraCommand compra) {

            ModelLayer.Result result = await _mediator.Send(compra);

            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("RegistrarDetalleCompra")]
        public async Task<IActionResult> RegistrarDetalleCompra([FromBody] DetalleCompraCommand detalleCompra) 
        {

            ModelLayer.Result result = await _mediator.Send(detalleCompra);

            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCompras() {

            ModelLayer.Result result = await _mediator.Send(new CompraQuery());

            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }

        }

    }
}
