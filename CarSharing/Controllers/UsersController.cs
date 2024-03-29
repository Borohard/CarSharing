﻿using System.Threading.Tasks;
using CarSharing.App.Users.Queries.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAll([FromQuery] GetUserListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}