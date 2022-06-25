using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class RequestHistoryController : ControllerBase
    {
        private readonly IRequestHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestHistoryController(
            IRequestHistoryRepository requestHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = requestHistoryRepository;
            this._unitOfWork = unitOfWork;
        }
        
        [HttpGet("v1/requestHistory")]
        public async Task<IActionResult> GetAllAsync()
        {
            var reHistoryList = await _repository.GetAllAsync();

            List<RequestHistoryDTO> reHistorysDTO = new List<RequestHistoryDTO>();

            foreach (RequestHistory reHistory in reHistoryList)
            {
                var reHistoryDTO = new RequestHistoryDTO()
                {
                    Id = reHistory.Id,
                    Status = reHistory.Status
                };

                reHistorysDTO.Add(reHistoryDTO);
            }

            return Ok(reHistorysDTO);
        }
    }
}