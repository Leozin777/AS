namespace Domain.Entities
{
    public class Status{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Request> Requests { get; set; }
    }
}