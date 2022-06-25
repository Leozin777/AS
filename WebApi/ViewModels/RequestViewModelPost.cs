using Domain.Entities;

namespace WebApi.ViewModels{
    public class RequestViewModelPost{
        public string Status { get; set; }
        public double AmountItems { get; set; }
        public int RequestDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
         public List<Item> Items { get; set; }
    }
}