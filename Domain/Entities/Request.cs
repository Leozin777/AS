namespace Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public double AmountItems { get; set; } // Valor total de items
        public DateTime RequestDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public List<Item> Items { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
    }
}