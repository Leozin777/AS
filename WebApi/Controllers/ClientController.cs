using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = clientRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/clients")]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientsList = await _repository.GetAllAsync();

            List<ClientDTO> clientsDTO = new List<ClientDTO>();

            foreach (Client client in clientsList)
            {
                var clientDTO = new ClientDTO()
                {
                    Id = client.Id,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    CPF = client.CPF,
                    DateLastPurchase = client.DateLastPurchase
                };

                clientsDTO.Add(clientDTO);
            }

            return Ok(clientsDTO);
        }

        [HttpGet("v1/clients/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
                return NotFound();
            else
            {
                var clientDTO = new ClientDTO()
                {
                    Id = client.Id,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    CPF = client.CPF,
                    DateLastPurchase = client.DateLastPurchase,
                    Requests = client.Requests
                };

                return Ok(clientDTO);
            }
        }

        [HttpPost("v1/clients")]
        public async Task<IActionResult> PostAsync([FromBody] ClientViewModelPost model)
        {
            var client = new Client
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                CPF = model.CPF,
                DateLastPurchase = model.DateLastPurchase
            };

            _repository.Save(client);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Cliente " + client.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("v1/clients/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var clientDeleted = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (clientDeleted == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/clients/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ClientViewModelPatch model)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
                return NotFound();
            else
            {
                client.Name = model.Name;
                client.PhoneNumber = model.PhoneNumber;

                _repository.Update(client);
                await _unitOfWork.CommitAsync();

                var clientDTO = new ClientDTO()
                {
                    Id = client.Id,
                    PhoneNumber = client.PhoneNumber
                };

                return Ok(clientDTO);
            }
        }
    }
}