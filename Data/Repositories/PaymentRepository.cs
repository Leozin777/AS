using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PaymentRepository: IPaymentRepository
{
    private readonly DataContext context;
    public PaymentRepository(DataContext context)
    {
        this.context = context;
    }
    public async Task<Payment> GetByIdAsync(int id)
    {
        return await context.Payments.SingleOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await context.Payments.ToListAsync();
    }

    public void Save(Payment t)
    {
        context.Payments.Add(t);
    }

    public bool Delete(int idT)
    {
        var payment = context.Payments.FirstOrDefault(i => i.Id == idT);

        if (payment == null)
            return false;
        else
        {
            context.Payments.Remove(payment);
            return true;
        }
    }

    public void Update(Payment t)
    {
        context.Entry(t).State = EntityState.Modified;
    }
}