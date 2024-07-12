﻿using Gourmet.API.Models;
using Gourmet.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gourmet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Создать (зарегестрировать) пользователя.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Идентификатор пользователя.</returns>
        [HttpPost("Register")]
        public async Task<ActionResult<int>> CreateUserAsync([FromBody] UserModel input)
        {
            var command = new CreateUserCommand(input.Name, input.Sex, input.Age);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Обновить профиль пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="input"></param>
        /// <returns>Идентификатор пользователя</returns>
        [HttpPut("{id}/Profile")]
        public async Task<ActionResult<int>> UpdateUserAsync([FromRoute]int id, [FromBody] UserModel input)
        {
            var command = new UpdateUserCommand(id, input.Name, input.Sex, input.Age);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
