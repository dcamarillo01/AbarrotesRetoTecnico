using BusinessLayer.CQRS.Commands.Venta;
using BusinessLayer.CQRS.Queries.Venta;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("RegistrarVenta")]
        public async Task<IActionResult> RegistarVenta([FromBody] RegistrarVentaCommand command)
        {
            ModelLayer.Result result = await _mediator.Send(command);
            if (result.Correct)
            {

                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("RegistrarDetalleVenta")]
        public async Task<IActionResult> RegistrarDetalleVenta([FromBody] RegistrarDetalleVentaCommand detalleVenta) 
        {

            ModelLayer.Result result = await _mediator.Send(detalleVenta);
            if (result.Correct)
            {
                return Ok(result);
            }
            else { 
                return BadRequest(result);
            }
        
        }

        [HttpGet("historial")]
        public async Task<IActionResult> GetHistorialVentas()
        {
            var result = await _mediator.Send(new HistorialVentasQuery());
            return result.Correct ? Ok(result) : BadRequest(result);
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll() 
        {

            ModelLayer.Result result = await _mediator.Send(new GetAllVentaQuery());

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
