using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(
            IItemRepository itemRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = itemRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/items")]
        public async Task<IActionResult> GetAllAsync()
        {
            var itemsList = await _repository.GetAllAsync();

            List<ItemDTO> itemsDTO = new List<ItemDTO>();

            foreach (Item item in itemsList)
            {
                var itemDTO = new ItemDTO()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Price = item.Price,
                    Missing = item.Missing,
                    RequestId = item.RequestId,
                };

                itemsDTO.Add(itemDTO);
            }


            return Ok(itemsDTO);
        }

        [HttpGet("v1/items/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item == null)
                return NotFound();
            else
            {
                var itemDTO = new ItemDTO()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Price = item.Price,
                    Missing = item.Missing,
                    RequestId = item.RequestId
                };

                return Ok(itemDTO);
            }
        }

        [HttpPost("v1/items")]
        public async Task<IActionResult> PostAsync([FromBody] ItemViewModel model)
        {
            var item = new Item
            {
                Amount = model.Amount,
                Price = model.Price,
                Missing = model.Missing,
                RequestId = model.RequestId
            };

            _repository.Save(item);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Itens " + item.Products + " foram adicionados com sucesso!"
            });
        }

        [HttpDelete("v1/items/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var itemDeleted = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (itemDeleted == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/items/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ItemViewModel model)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item == null)
                return NotFound();
            else
            {
                item.Amount = model.Amount;
                item.Price = model.Price;
                item.Missing = model.Missing;
                item.RequestId = model.RequestId;

                _repository.Update(item);
                await _unitOfWork.CommitAsync();

                var itemDTO = new ItemDTO()
                {
                    Amount = model.Amount,
                    Price = model.Price,
                    RequestId = model.RequestId,
                    Missing = model.Missing
                };

                return Ok(itemDTO);
            }
        }
    }
}