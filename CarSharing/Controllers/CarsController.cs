using System.Threading.Tasks;
using CarSharing.App.Cars.Commands;
using CarSharing.App.Cars.Queries.GetCarsList;
using CarSharing.App.Cars.Queries.GetRentalsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CarDto>> GetAll([FromQuery] GetCarsListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Rentals")]
        public async Task<ActionResult<RentalDto>> GetAllOrders([FromQuery] GetRentalsListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("Rentals")]
        public async Task<ActionResult<CarDto>> OrderBook([FromBody] RentalCarCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
