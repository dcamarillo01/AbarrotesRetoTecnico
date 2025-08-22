using BusinessLayer.CQRS.Commands.Inventario;
using BusinessLayer.CQRS.Queries.Inventario;
using BusinessLayer.CQRS.Queries.Venta;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {

        private readonly IMediator _mediator;

        public InventarioController(IMediator mediator) => _mediator = mediator;


        [HttpGet("General")]
        public async Task<IActionResult> InventarioGeneral()
        {
            var result = await _mediator.Send(new InventarioGeneralQuery());
            return result.Correct ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        [Route("PorSucursal")]
        public async Task<IActionResult> InventarioPorSucursal([FromQuery] int? IdSucursal) {

            var result = await _mediator.Send(new InventarioSucursalQuery(IdSucursal));
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("RegistrarInventario")]
        public async Task<IActionResult> RegistrarInventario([FromBody] InventarioCommand inventario) 
        {

            ModelLayer.Result result = await _mediator.Send(inventario);
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
