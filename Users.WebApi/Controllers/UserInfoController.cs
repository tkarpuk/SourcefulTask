using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Users.WebApi.DTO;
using AutoMapper;
using Users.Application.Users.Commands;

namespace Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserInfoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser(UserDto userDto)
        {
            var command = _mapper.Map<CreateUserCommand>(userDto);            
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }
    }
}
