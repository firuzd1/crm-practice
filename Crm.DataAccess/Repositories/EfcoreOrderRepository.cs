using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Crm.DataAccess;
public sealed class EfcoreOrderRepository : IOrderRepository
{
    private readonly CrmDbContex _db;
    public EfcoreOrderRepository(CrmDbContex crmDbContex)
    {
        _db = crmDbContex;
    }

    public EfcoreOrderRepository()
    {
        _db = new();
    }
    public async ValueTask<bool> ChangeDescriptionAsync(string find, string newDescription, CancellationToken cancellationToken = default)
    {
        try
        {
            Order order = await _db.order.FirstOrDefaultAsync(o => o.Description == find, cancellationToken);
            order.Description = newDescription;
            _db.Update(order);
            return await _db.SaveChangesAsync(cancellationToken) > 1;
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Ошибка при изменении описания: " + ex.Message);
            return false;
        }
    }
    public async ValueTask<bool> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _db.order.AddAsync(order, cancellationToken);
        return await _db.SaveChangesAsync(cancellationToken) > 0;
    }
    public async ValueTask<bool> DeleteOrderAsync(string forDelete, CancellationToken cancellationToken = default)
    {
        try
        {
            Order? orderToDelete = await _db.order.FirstOrDefaultAsync(o => o.Description == forDelete, cancellationToken);

            if(orderToDelete is null)
            {
                _db.order.Remove(orderToDelete);
                await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            else return false;
        }catch(Exception ex)
        {
            System.Console.WriteLine("Ошибка при удалении: " + ex.Message);
            return false;
        }
    }
    public async ValueTask<Order> GetOrderAsync(string myOrderDescription, CancellationToken cancellationToken = default)
    {
        Order order = await _db.order.AsNoTracking().FirstOrDefaultAsync(o => o.Description == myOrderDescription, cancellationToken);
        return order;
    }
    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default)
    {
        return  new(_db.order.CountAsync(cancellationToken));
    }
    public ValueTask<int> GetOrderCountAsync(OrderState orderState, CancellationToken cancellationToken = default)
    {
        return new(_db.order.CountAsync(o => o.MyOrderState == orderState, cancellationToken));
    }
    public async ValueTask<bool> UpdateOrderStateAsync(long orderId, OrderState orderState, CancellationToken cancellationToken = default)
    {
        Order order = await _db.order.AsNoTracking().SingleAsync(o => o.Id == orderId, cancellationToken);
        order.MyOrderState = orderState;
        //_db.Update(order);
        //_db.Entry(order).State = EntityState.Modified;
        return await _db.SaveChangesAsync(cancellationToken) > 0;

    }
}