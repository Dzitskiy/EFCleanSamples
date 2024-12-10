using AppServices.Users.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Пользователи.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получить данные всех пользователей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список пользователей.</returns>
        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetAllUsersAsync(CancellationToken token)
        {
            var users = await _userService.GetAllAsync(token);
            return Ok(users);        
        }

        /// <summary>
        /// Получить данные пользователя по Id.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Модель пользователя.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid id, CancellationToken token)
        {
            var user = await _userService.GetByIdAsync(id, token);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="userRequest">Модель пользователя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Идентификатор нового пользователя.</returns>
        [HttpPost()]
        public async Task<ActionResult<User>> CreateUserAsync(User userRequest, CancellationToken token)
        {
            var user = userRequest;

            await _userService.CreateAsync(userRequest, token);

            return Ok(user);        
        }

        /// <summary>
        /// Обновить информацию о пользователе.
        /// </summary>
        /// <param name="userRequest">Модель пользователя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        [HttpPut()]
        public async Task<ActionResult<User>> UpdateUserAsync(User userRequest, CancellationToken token)
        {
            var currentUser = await _userService.GetByIdAsync(userRequest.Id, token);

            if (currentUser != null)
            {
                await _userService.CreateAsync(currentUser, token);
            }

            return Ok();
        }

        /// <summary>
        /// Удаление пользователя по Id.
        /// </summary>
        /// <param name="id">Идентификатор пользоваеля.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [HttpDelete()]
        public async Task<ActionResult<User>> DeleteUserAsync(Guid id, CancellationToken token)
        {
            var currentUser = await _userService.GetByIdAsync(id, token);

            if (currentUser != null)
            {
                await _userService.DeleteAsync(id, token);
            }

            return Ok();
        }
    }
}