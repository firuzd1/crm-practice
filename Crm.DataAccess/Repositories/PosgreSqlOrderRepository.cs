using Npgsql;

namespace Crm.DataAccess;

public static class SqlHelper
{
    public static string ConnectionString = "Server=localhost;Port=5432;User ID=postgres;Password=12345;Database=Alif-academy-db";
}

public sealed class PosgreSqlOrderRepository : IOrderRepository
{
    private readonly NpgsqlConnection _npgsqlConnection;
    public PosgreSqlOrderRepository(NpgsqlConnection npgsqlConnection)
    {
        _npgsqlConnection = npgsqlConnection;
    }

    public PosgreSqlOrderRepository()
    {
        _npgsqlConnection = new(SqlHelper.ConnectionString);
    }

    public bool ChangeDescription(string find, string newDescription)
    {
        throw new NotImplementedException();
    }

    public bool Create(Order order)
    {
        try
        {
            _npgsqlConnection.Open();

            string insertQuery = "INSERT INTO \"order\" (description, price, delivery_type, delivery_address, my_order_state) " +
                            "VALUES (@Description, @Price, @DeliveryType, @DeliveryAddress, @MyOrderState)";

            using NpgsqlCommand npgsqlCommand = new(insertQuery, _npgsqlConnection);

            npgsqlCommand.Parameters.AddWithValue("@Description", order.Description);
            npgsqlCommand.Parameters.AddWithValue("@Price", order.Price);
            npgsqlCommand.Parameters.AddWithValue("@DeliveryType", order.DeliveryType);
            npgsqlCommand.Parameters.AddWithValue("@DeliveryAddress", order.DeliveryAddress);
            npgsqlCommand.Parameters.AddWithValue("@MyOrderState", order.MyOrderState);

            int rowAffected = npgsqlCommand.ExecuteNonQuery();

            _npgsqlConnection.Close();

            return rowAffected > 0;
        }
        catch (Exception ex)
        {

            System.Console.WriteLine("Ошибка при создании: " + ex.Message);
            return false;
        }
    }

    public bool DeleteOrder(string forDelete)
    {
        try
        {
            bool idForDel = int.TryParse(forDelete, out int OrderId);
            if (!idForDel)
                return false;
            _npgsqlConnection.Open();
            string deleteQuery = "DELETE FROM \"order\" WHERE id = @OrderId";

            using NpgsqlCommand npgsqlCommand = new(deleteQuery, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@OrderId", OrderId);

            int rowAffected = npgsqlCommand.ExecuteNonQuery();
            return rowAffected > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Ошибка при удалении заказа: " + ex.Message);
            return false;
        }
    }

    public Order? GetOrder(string myOrderDescription)
    {
        throw new NotImplementedException();
    }

    public int GetOrderCount()
    {
        int orderCount = 0;
        _npgsqlConnection.Open();
        NpgsqlCommand npgsqlCommand = new("SELECT COUNT(*) FROM \"order\"", _npgsqlConnection);

        using NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
        while (npgsqlDataReader.Read())
        {
            if (!npgsqlDataReader.IsDBNull(0))
            {
                orderCount = npgsqlDataReader.GetInt32(0);
            }
        }
        _npgsqlConnection.Close();

        return orderCount;
    }

    public int GetOrderCount(OrderState orderState)
    {
        try
        {
            string countQuery = "SELECT COUNT(*) FROM \"order\" WHERE my_order_state = @OrderState";
            _npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = new(countQuery, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@OrderState", orderState);

            int count = Convert.ToInt32(npgsqlCommand.ExecuteScalar());
            return count;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Ошибка при получении статистики состояния заказа" + ex.Message);
            return -1;
        }

    }

    public bool UpdateOrderState(long orderId, OrderState orderState)
    {
        try
        {
            _npgsqlConnection.Open();

            string updateQuery = "UPDATE \"order\" SET my_order_state = @OrderState WHERE id = @OrderId";

            using NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, _npgsqlConnection);
            cmd.Parameters.AddWithValue("@OrderState", orderState);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при обновлении состояния заказа: " + ex.Message);
            return false;
        }
    }
}