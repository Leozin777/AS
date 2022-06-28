using Domain.Entities;

namespace WebApi.ViewModels
{
	public class ItemViewModel
	{
        public int Amount { get; set; } 
        public double Price { get; set; } 
        public bool Missing { get; set; }
         public int RequestId { get; set; }

    }
}