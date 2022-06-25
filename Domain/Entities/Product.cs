namespace Domain.Entities{

    public class Product{
        public int Id { get; set; }
        public Double Price { get; set; }
        public string Name { get; set; }
        public int SoldAmount { get; set; }
        public Double QuantityKgSold { get; set; }
        public Item Item { get; set; }
    }
    
}