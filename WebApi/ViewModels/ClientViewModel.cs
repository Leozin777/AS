namespace WebApi.ViewModels
{
	public class ClientViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
         public string CPF { get; set; }
        public DateTime dateLastPurchase { get; set; } //Data da última compra
    }
}
