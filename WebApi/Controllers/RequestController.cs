using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestController(
            IRequestRepository requestRepository,
            IUnitOfWork unitOfWork
            )
        {
            this._repository = requestRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/requests")]
        public async Task<IActionResult> GetAllAsync()
        {
            var requestsList = await _repository.GetAllAsync();

            List<RequestDTO> requestsDTO = new List<RequestDTO>();

            foreach (Request request in requestsList)
            {
                var requestDTO = new RequestDTO()
                {
                    Id = request.Id,
                    AmountItems = request.AmountItems,
                    RequestDate = request.RequestDate,
                    ClientId = request.ClientId,
                    StoreId = request.StoreId,
                    PaymentId = request.PaymentId,
                    StatusId = request.StatusId
                };

                requestsDTO.Add(requestDTO);
            }

            return Ok(requestsDTO);
        }

        [HttpGet("v1/requests/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var request = await _repository.GetByIdAsync(id);

            if (request == null)
                return NotFound();
            else
            {
                var requestDTO = new RequestDTO()
                {
                    Id = request.Id,
                    AmountItems = request.AmountItems,
                    RequestDate = request.RequestDate,
                    ClientId = request.ClientId,
                    StoreId = request.StoreId,
                    PaymentId = request.PaymentId,
                    StatusId = request.StatusId
                };

                return Ok(requestDTO);
            }
        }

        [HttpPost("v1/requests")]
        public async Task<IActionResult> PostAsync([FromBody] RequestViewModel model)
        {
            var request = new Request
            {
                AmountItems = model.AmountItems,
                RequestDate = model.RequestDate,
                ClientId = model.ClientId,
                StoreId = model.StoreId,
                PaymentId = model.PaymentId,
                StatusId = model.StatusId
            };
            _repository.Save(request);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Pedido " + request.Id + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("v1/requests/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var requestDeleted = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (requestDeleted == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/requests/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] RequestViewModel model)
        {
            var request = await _repository.GetByIdAsync(id);

            if (request == null)
                return NotFound();
            else
            {
                request.AmountItems = model.AmountItems;
                request.RequestDate = model.RequestDate;
                request.ClientId = model.ClientId;
                request.StoreId = model.StoreId;
                request.PaymentId = model.PaymentId;
                request.StatusId = model.StatusId;

                _repository.Update(request);
                await _unitOfWork.CommitAsync();

                var requestDTO = new RequestDTO()
                {
                    Id = request.Id,
                    AmountItems = request.AmountItems,
                    RequestDate = request.RequestDate,
                    ClientId = request.ClientId,
                    StoreId = request.StoreId,
                    PaymentId = request.PaymentId,
                    StatusId = request.StatusId
                };

                return Ok(requestDTO);
            }
        }
    }
}