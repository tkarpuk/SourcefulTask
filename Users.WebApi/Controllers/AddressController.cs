using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Addresses.Commands;
using Users.Application.Addresses.Queries;
using Users.WebApi.Common;
using Users.WebApi.DTO;

namespace Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AddressController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetList(Guid id)
        {
            var query = new GetAddressListQuery()
            {
                UserId = id,
                PageSize = Request.Query["pageSize"].ToString().StrToIntDefault(10),
                PageN = Request.Query["pageN"].ToString().StrToIntDefault(1)
            };
            var addressesList = _mapper.Map<IEnumerable<AddressDto>>(await _mediator.Send(query));

            return Ok(addressesList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetDetails(Guid id)
        {
            var query = new GetAddressDetailsQuery()
            {
                Id = id
            };
            var address = _mapper.Map<AddressDto>(await _mediator.Send(query));

            return address;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddressCreateDto addressCreateDto)
        {
            var command = _mapper.Map<CreateAddressCommand>(addressCreateDto);
            var addressId = await _mediator.Send(command);
            return Ok(addressId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
        {
            var command = _mapper.Map<UpdateAddressCommand>(addressUpdateDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAddressCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
