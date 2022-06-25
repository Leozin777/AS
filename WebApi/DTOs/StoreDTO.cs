using Domain.Entities;

namespace WebApi.DTOs;

public class StoreDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public List<Request> Requests { get; set; }
}