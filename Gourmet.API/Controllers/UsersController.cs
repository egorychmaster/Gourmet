using Gourmet.API.Models;
using Gourmet.Application.Commands.Favorites;
using Gourmet.Application.Commands.Users;
using Gourmet.Application.Queries.Favorites;
using Gourmet.Application.Queries.Users;
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
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <param name="input"></param>
        /// <returns>Идентификатор пользователя</returns>
        [HttpPut("{currentUserId}/Profile")]
        public async Task<ActionResult<int>> UpdateUserAsync([FromRoute]int currentUserId, [FromBody] UserModel input)
        {
            var command = new UpdateUserCommand(currentUserId, input.Name, input.Sex, input.Age);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        #region Favorites
        /// <summary>
        /// Вернуть список любимых блюд пользователя.
        /// </summary>
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <returns>Блюда.</returns>
        [HttpGet("{currentUserId}/FavoriteDishes")]
        public async Task<ActionResult<IEnumerable<DishModel>>> GetFavoriteDishesByUserAsync([FromRoute] int currentUserId)
        {
            var query = new GetFavoriteDishesByUserQuery(currentUserId);
            var result = await _mediator.Send(query);
            return Ok(result.Select(x => new DishModel(x.Id, x.Name)));
        }

        /// <summary>
        /// Добавить любимое блюдо пользователю.
        /// </summary>
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <param name="dishId">Идентификатор блюда.</param>
        /// <returns></returns>
        [HttpPost("{currentUserId}/FavoriteDishes/{dishId}")]
        public async Task<ActionResult> AddFavoriteDishToUserAsync([FromRoute] int currentUserId, int dishId)
        {
            var command = new AddFavoriteDishToUserCommand(currentUserId, dishId);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удалить блюдо из любимых у пользователя.
        /// </summary>
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <param name="dishId"></param>
        /// <returns></returns>
        [HttpDelete("{currentUserId}/FavoriteDishes/{dishId}")]
        public async Task<ActionResult> DeleteUsersFavoriteDishAsync([FromRoute] int currentUserId, int dishId)
        {
            var command = new DeleteUsersFavoriteDishCommand(currentUserId, dishId);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Отправить лайк на определенное блюдо пользователя.
        /// </summary>
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <param name="dishId">Идентификатор блюда.</param>
        /// <param name="userId">Идентификатор пользователя, блюду которого ставят лайк.</param>
        /// <returns></returns>
        [HttpPost("{currentUserId}/FavoriteDishes/{dishId}/User/{userId}/Like")]
        public async Task<ActionResult> SetLikeFavoriteDishAsync([FromRoute] int currentUserId, int dishId, int userId)
        {
            var command = new SetLikeFavoriteDishCommand(currentUserId, dishId, userId);
            await _mediator.Send(command);
            return Ok();
        }
        #endregion Favorites


        /// <summary>
        /// Фильтр по другим пользователям.
        /// </summary>
        /// <param name="currentUserId">Идентификатор текущего пользователя.</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("{currentUserId}/Filter")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetFilterAsync(
            [FromRoute] int currentUserId, FilterModel filter)
        {
            var query = new GetFilterUsersQuery(currentUserId, filter.Sex, filter.Age, filter.DishIds);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
