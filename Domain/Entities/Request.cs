namespace Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double AmountItems { get; set; }
        public int RequestDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }
    }
}