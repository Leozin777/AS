using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers;
{
    [Route("api/")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = paymentRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/payments")]
        public async Task<IActionResult> GetAllAsync()
        {
            var paymentsList = await _repository.GetAllAsync();

            List<PaymentDTO> paymentsDTO = new List<PaymentDTO>();

            foreach (Payment payment in paymentsList)
            {
                var paymentDTO = new PaymentDTO()
                {
                    Id = payment.Id,
                    Description = payment.Description
                };
                
                paymentsDTO.Add(paymentDTO);
            }

            return Ok(paymentsDTO);
        }

        [HttpGet("v1/payments/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var payment = await _repository.GetByIdAsync(id);

            if (payment == null)
                return NotFound();
            else
            {
                var paymentDTO = new PaymentDTO()
                {
                    Id = payment.Id,
                    Description = payment.Description
                };
                return Ok(paymentDTO);
            }
        }

        [HttpPost("v1/payments")]
        public async Task<IActionResult> PostAsync([FromBody] PaymentViewModel model)
        {
            var payment = new Payment()
            {
                Description = model.Description
            };
            
            _repository.Save(payment);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Forma de pagamento " + payment.Description + " foi adicionada com sucesso!"
            });
        }
        
        [HttpDelete("v1/payments/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var paymentDelete = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (paymentDelete == false)
                return NotFound();
            else
                return Ok(id);
        }
        
        [HttpPatch("v1/payments/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] PaymentViewModel model)
        {
            var payment = await _repository.GetByIdAsync(id);

            if (payment == null)
                return NotFound();
            else
            {
                payment.Description = model.Description;

                _repository.Update(payment);
                await _unitOfWork.CommitAsync();

                var paymentDTO = new PaymentDTO()
                {
                    Description = payment.Description
                };

                return Ok(paymentDTO);
            }
        }
    }
}    