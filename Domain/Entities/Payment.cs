namespace Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public List<Request> Requests { get; set; }
}