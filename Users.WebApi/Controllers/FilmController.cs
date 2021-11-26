using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Films.Commands;
using Users.Application.Films.Queries;
using Users.WebApi.Common;
using Users.WebApi.DTO;

namespace Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FilmController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetList(Guid id)
        {
            var query = new GetFilmListQuery()
            {
                UserId = id,
                PageSize = Request.Query["pageSize"].ToString().StrToIntDefault(10),
                PageN = Request.Query["pageN"].ToString().StrToIntDefault(1)
            };
            var filmList = _mapper.Map<IEnumerable<FilmDto>>(await _mediator.Send(query));

            return Ok(filmList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto>> GetDetails(Guid id)
        {
            var query = new GetFilmDetailsQuery()
            {
                Id = id
            };
            var film = _mapper.Map<FilmDto>(await _mediator.Send(query));

            return film;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(FilmCreateDto filmCreateDto)
        {
            var command = _mapper.Map<CreateFilmCommand>(filmCreateDto);
            var filmId = await _mediator.Send(command);
            return Ok(filmId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FilmUpdateDto filmUpdateDto)
        {
            var command = _mapper.Map<UpdateFilmCommand>(filmUpdateDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFilmCommand()
            {
                Id = id
            };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
