using Domain.Entities;

namespace WebApi.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; } 
        public int Amount { get; set; } 
        public double Price { get; set; } 
        public bool Missing { get; set; }
         public int RequestId { get; set; } 

    }
}