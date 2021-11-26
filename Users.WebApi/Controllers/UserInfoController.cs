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
using Users.WebApi.Common;
using Users.Application.Users.Queries;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var query = new GetUserListQuery()
            {
                PageSize = Request.Query["pageSize"].ToString().StrToIntDefault(10),
                PageN = Request.Query["pageN"].ToString().StrToIntDefault(1)
            };
            var userList = _mapper.Map<IEnumerable<UserDto>>(await _mediator.Send(query));

            return Ok(userList);
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
