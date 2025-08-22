using BusinessLayer.CQRS.Commands.Producto;
using BusinessLayer.CQRS.Queries.Producto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _mediator.Send(new ProductoQuery());
            return Ok(productos);   
        }


        [HttpPost]
        [Route("ProductoAdd")]
        public async Task<IActionResult> ProductoAdd([FromBody] ProductoAddCommand productoAdd) 
        {

            ModelLayer.Result result = await _mediator.Send(productoAdd);
            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
        
        }

        [HttpPut]
        [Route("ProductoUpdate")]
        public async Task<IActionResult> ProductoUpdate([FromBody] ProductoUpdateCommand producto) {

            ModelLayer.Result result = await _mediator.Send(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else {
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("ProductoStatus")]
        public async Task<IActionResult> CambiarStatus([FromBody] ProductoStatusCommand status) { 
        
            ModelLayer.Result result = await _mediator.Send(status);
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
