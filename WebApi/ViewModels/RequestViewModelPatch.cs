using Domain.Entities;

namespace WebApi.ViewModels{
    public class RequestViewModelPatch{
        public string Status { get; set; }
        public double AmountItems { get; set; } // Valor total de items
        public Client Client { get; set; }
        public int ClientId { get; set; }
         public List<Item> Items { get; set; }
    }
}
