using Domain.Entities;

namespace WebApi.DTOs{
    public class ProductDTO{
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int? SoldAmount { get; set; }
        public double? QuantityKgSold { get; set; }
         public int ItemId { get; set; }
    }
}
