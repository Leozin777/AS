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
    }
}

// builder.HasOne(x => x.Client)
//                 .WithMany(x => x.Requests)
//                 .HasConstraintName("FK_Charge_Customer")
//                 .OnDelete(DeleteBehavior.Restrict);