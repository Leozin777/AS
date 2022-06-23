using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(
            IUserRepository alunoRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = alunoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAllAsync()
        {
            var usersList = await _repository.GetAllAsync();

            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach (User user in usersList)
            {
                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Username = user.Username
                };

                usersDTO.Add(userDTO);
            }

            return Ok(usersDTO);
        }

        [HttpGet("v1/users/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            else
            {
                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Username = user.Username
                };

                return Ok(userDTO);
            }
        }

        [HttpPost("v1/users")]
        public async Task<IActionResult> PostAsync([FromBody] UserViewModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            _repository.Save(user);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "User " + user.Username + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("v1/users/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var userDeleted = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (userDeleted == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/users/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UserViewModel model)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            else
            {
                user.Username = model.Username;
                user.Email = model.Email;
                user.Password = model.Password;

                _repository.Update(user);
                await _unitOfWork.CommitAsync();

                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Username = user.Username
                };

                return Ok(userDTO);
            }
        }
    }
}