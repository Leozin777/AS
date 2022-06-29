using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StatusController(
            IStatusRepository requestHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = requestHistoryRepository;
            this._unitOfWork = unitOfWork;
        }
        
        [HttpGet("v1/status")]
        public async Task<IActionResult> GetAllAsync()
        {
            var statusList = await _repository.GetAllAsync();

            List<StatusDTO> statusListDTO = new List<StatusDTO>();

            foreach (Status status in statusList)
            {
                var statusDTO = new StatusDTO()
                {
                    Id = status.Id,
                    Name = status.Name
                };

                statusListDTO.Add(statusDTO);
            }

            return Ok(statusListDTO);
        }
    }
}