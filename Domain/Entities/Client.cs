
namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public DateTime DateLastPurchase { get; set; } //Data da última compra
        public List<Request> Requests { get; set; }
    }
}