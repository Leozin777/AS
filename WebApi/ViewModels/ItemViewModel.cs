using Domain.Entities;

namespace WebApi.ViewModels
{
	public class ItemViewModel
	{
        public List<Product> Products { get; set; }
        public int Amount { get; set; } 
        public double Price { get; set; } 
        public Request Request { get; set; }
         public bool Missing { get; set; }
    }
}