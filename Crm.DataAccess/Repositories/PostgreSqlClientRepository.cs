using System;
using Npgsql;

namespace Crm.DataAccess;

public class PostgreSqlClientRepository : IClientRepository
{

    private readonly NpgsqlConnection _npgsqlConnection;

    public PostgreSqlClientRepository(NpgsqlConnection npgsqlConnection)
    {
        _npgsqlConnection = npgsqlConnection;
    }

    public PostgreSqlClientRepository()
    {
        _npgsqlConnection = new(SqlHelper.ConnectionString);
    }
    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname)
    {
        try
        {
            _npgsqlConnection.OpenAsync();
            string changeQuerty = "UPDATE client SET first_name = @newFirstName, last_name = @newLastname WHERE first_name = @name AND last_name = @lastName";
            using NpgsqlCommand npgsqlCommand = new(changeQuerty, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@newFirstName", newFirstName);
            npgsqlCommand.Parameters.AddWithValue("@newLastName", newLastname);
            npgsqlCommand.Parameters.AddWithValue("@name", name);
            npgsqlCommand.Parameters.AddWithValue("@lastName", lastName);

            int rowAffected = npgsqlCommand.ExecuteNonQuery();

            return rowAffected > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Ошибка при изменении: " + ex.Message);
            return false;
        }
        finally
        {
            _npgsqlConnection.Close();
        }
    }

    public bool CreateClient(Client client)
    {
        try
        {
            _npgsqlConnection.Open();
            string clientQuery = "INSERT INTO client(first_name, last_name, middle_name, age, passport_number, gender, phone, email, user_password)" +
             "VALUES (@FirstName, @LastName, @MiddleName, @Age, @PassportNumber, @Gender, @Phone, @Email, @Password)";

            using NpgsqlCommand npgsqlCommand = new(clientQuery, _npgsqlConnection);

            npgsqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
            npgsqlCommand.Parameters.AddWithValue("@LastName", client.LastName);
            npgsqlCommand.Parameters.AddWithValue("@MiddleName", client.MiddleName);
            npgsqlCommand.Parameters.AddWithValue("@Age", client.Age);
            npgsqlCommand.Parameters.AddWithValue("@PassportNumber", client.PassportNumber);
            npgsqlCommand.Parameters.AddWithValue("@Gender", client.Gender);
            npgsqlCommand.Parameters.AddWithValue("@Phone", client.UserPhone);
            npgsqlCommand.Parameters.AddWithValue("@Email", client.UserEmail);
            npgsqlCommand.Parameters.AddWithValue("@Password", client.UserPassword);

            int rowAffected = npgsqlCommand.ExecuteNonQuery();

            return rowAffected > 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Ошибка при создании: " + ex.Message);
            return false;
        }
        finally
        {
            _npgsqlConnection.Close();
        }
    }

    public Client GetClient(string firstName, string lastName)
    {
        try
        {
            _npgsqlConnection.Open();
            string query = "SELECT * FROM client WHERE first_name = @firstName AND last_name = @lastName";

            using NpgsqlCommand npgsqlCommand = new(query, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@firstName", firstName);
            npgsqlCommand.Parameters.AddWithValue("@lastName", lastName);

            using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

            if (reader.Read())
            {

                int id = reader.GetInt32(reader.GetOrdinal("id"));
                string clientFirstName = reader.GetString(reader.GetOrdinal("first_name"));
                string clientLastName = reader.GetString(reader.GetOrdinal("last_name"));
                string clientMiddleName = reader.GetString(reader.GetOrdinal("middle_name"));
                short clientAge = reader.GetInt16(reader.GetOrdinal("age"));
                string clientPassport = reader.GetString(reader.GetOrdinal("passport_number"));
                string clientGenderInt = reader.GetString(reader.GetOrdinal("gender"));
                string clientPhone = reader.GetString(reader.GetOrdinal("phone"));
                string clientEmail = reader.GetString(reader.GetOrdinal("email"));
                string clientPassword = reader.GetString(reader.GetOrdinal("user_password"));



                Client client = new Client
                {
                    Id = id,
                    FirstName = clientFirstName,
                    LastName = clientLastName,
                    MiddleName = clientMiddleName,
                    Age = clientAge,
                    PassportNumber = clientPassport,
                    Gender = Gender.male,
                    UserPhone = clientPhone,
                    UserEmail = clientEmail,
                    UserPassword = clientPassword
                };
                return client;
            }


            return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Ошибка при получении клиента: " + ex.Message);
            return null;
        }
        finally
        {
            _npgsqlConnection.Close();
        }
    }

    public int GetClientCount()
    {
        throw new NotImplementedException();
    }
}