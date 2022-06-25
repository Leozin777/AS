using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            this._repository = productRepository;
            this._unitOfWork = unitOfWork;
        }
        [HttpGet("v1/products")]
        public async Task<IActionResult> GetAllAsync()
        {
            var productsList = await _repository.GetAllAsync();

            List<ProductDTO> productsDTO = new List<ProductDTO>();

            foreach (Product product in productsList)
            {
                var productDTO = new ProductDTO()
                {
                    Id = product.Id,
                    Price = product.Price,
                    Name = product.Name,
                    SoldAmount = product.SoldAmount,
                    QuantityKgSold = product.QuantityKgSold,
                    Item = product.Item
                };

                productsDTO.Add(productDTO);
            }

            return Ok(productsDTO);
        }

        [HttpGet("v1/products/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();
            else
            {
                var productDTO = new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    SoldAmount = product.SoldAmount,
                    Item = product.Item
                };

                return Ok(productDTO);
            }
        }

        [HttpPost("v1/products")]
        public async Task<IActionResult> PostAsync([FromBody] ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                SoldAmount = model.SoldAmount,
                Item = model.Item
            };

            _repository.Save(product);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Produto " + product.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("v1/products/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var productDeleted = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (productDeleted == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("v1/products/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ProductViewModel model)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return NotFound();
            else
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.SoldAmount = model.SoldAmount;
                product.Item = model.Item;

                _repository.Update(product);
                await _unitOfWork.CommitAsync();

                var productDTO = new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    SoldAmount = product.SoldAmount,
                    Item = product.Item
                };

                return Ok(productDTO);
            }
        }
    }
}