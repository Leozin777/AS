namespace Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double AmountItems { get; set; } // Valor total de items
        public int RequestDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public List<Item> Items { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
    }
}