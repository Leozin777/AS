using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]

    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StoreController(
            IStoreRepository storeRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = storeRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/stores")]
        public async Task<IActionResult> GetAllAsync()
        {
            var storesList = await _repository.GetAllAsync();

            List<StoreDTO> storesDTO = new List<StoreDTO>();

            foreach (Store store in storesList)
            {
                var storeDTO = new StoreDTO()
                {
                    Id = store.Id,
                    Name = store.Name,
                    PhoneNumber = store.PhoneNumber,
                    Address = store.Address
                };

                storesDTO.Add(storeDTO);
            }

            return Ok(storesDTO);
        }

        [HttpGet("v1/stores/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var store = await _repository.GetByIdAsync(id);

            if (store == null)
                return NotFound();
            else
            {
                var storeDTO = new StoreDTO()
                {
                    Id = store.Id,
                    Address = store.Address,
                    Name = store.Name,
                    PhoneNumber = store.PhoneNumber,
                    Requests = store.Requests
                };

                return Ok(storeDTO);
            }
        }

        [HttpPost("v1/stores")]
        public async Task<IActionResult> PostAsync([FromBody] StoreViewModel model)
        {
            var store = new Store
            {
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            _repository.Save(store);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Loja " + store.Name + " foi cadastrada com sucesso!"
            });
        }

        [HttpDelete("v1/stores/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var storeDelete = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (storeDelete == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/stores/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] StoreViewModel model)
        {
            var store = await _repository.GetByIdAsync(id);

            if (store == null)
                return NotFound();
            else
            {
                store.Name = model.Name;
                store.PhoneNumber = model.PhoneNumber;
                store.Address = model.Address;

                _repository.Update(store);
                await _unitOfWork.CommitAsync();

                var storeDTO = new StoreDTO()
                {
                    Id = store.Id,
                    Name = model.Name
                };

                return Ok(storeDTO);
            }
        }
    }
}