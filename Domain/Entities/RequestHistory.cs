namespace Domain.Entities
{
    public class RequestHistory{
        public int Id { get; set; }

        public bool Status { get; set; }

        public List<Request> Requests { get; set; }
    }
}