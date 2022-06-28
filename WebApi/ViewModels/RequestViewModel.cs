using Domain.Entities;

namespace WebApi.ViewModels{
    public class RequestViewModel{
        public double AmountItems { get; set; }
        public DateTime RequestDate { get; set; }
        public int ClientId { get; set; }
        public int StoreId { get; set; }
        public int PaymentId { get; set; }
        public int StatusId { get; set; }

    }
}