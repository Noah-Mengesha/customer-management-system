using Microsoft.Data.SqlClient;
using System.Data;

namespace CustomerClassLibrary
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=CustomerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Add(Customer customer)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_AddCustomer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", customer.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Street", customer.Street);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Zip", customer.Zip);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Customer customer)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", customer.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Street", customer.Street);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Zip", customer.Zip);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int customerId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public Customer GetCustomer(int customerId)
        {
            Customer customer = new Customer();

            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_GetCustomer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                customer.FirstName = reader["FirstName"].ToString();
                customer.MiddleName = reader["MiddleName"].ToString();
                customer.LastName = reader["LastName"].ToString();
                customer.Street = reader["Street"].ToString();
                customer.City = reader["City"].ToString();
                customer.State = reader["State"].ToString();
                customer.Zip = reader["Zip"].ToString();
            }

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_GetAllCustomers", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new Customer
                {
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    FirstName = reader["FirstName"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Street = reader["Street"].ToString(),
                    City = reader["City"].ToString(),
                    State = reader["State"].ToString(),
                    Zip = reader["Zip"].ToString()
                };

                customers.Add(customer);
            }

            return customers;
        }
    }
}