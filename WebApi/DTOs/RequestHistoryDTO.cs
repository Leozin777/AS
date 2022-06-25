using Domain.Entities;

namespace WebApi.DTOs;

public class RequestHistoryDTO
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public List<Request> Requests { get; set; }
}