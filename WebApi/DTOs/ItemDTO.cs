using Domain.Entities;

namespace WebApi.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; } 
        public List<Product> Products { get; set; }
        public int Amount { get; set; } 
        public double Price { get; set; } 
        public Request Request { get; set; } 
         public int RequestId { get; set; } 
         public bool Missing { get; set; }


    }
}