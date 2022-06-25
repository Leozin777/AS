using Domain.Entities;

namespace WebApi.DTOs{
    public class RequestDTO{
        public int Id { get; set; }
        public string Status { get; set; }
        public double AmountItems { get; set; }
        public int RequestDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
         public List<Item> Items { get; set; }
    }
}