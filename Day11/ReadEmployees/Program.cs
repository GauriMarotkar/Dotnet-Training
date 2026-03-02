using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString = @"Server=localhost\SQLEXPRESS;Database=TestDB1;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

    static void Main()
    {
        

        //ReadData();
        //AdapterOperation();
        //NonQueryOperation();
        //ParameterizedQueryOperation();
        //ScalarOperation();
        SqlInjectionOperation();
    }

    // 1. READ using SqlDataReader
    static void ReadData()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT EmployeeID, FirstName, LastName, Department FROM Employees";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("EmployeeID | FirstName | LastName | Department");
            Console.WriteLine("---------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmployeeID"]} | {reader["FirstName"]} | {reader["LastName"]} | {reader["Department"]}");
            }
            reader.Close();
        }
    }

    // 2. Adapter operation
    static void AdapterOperation()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT EmployeeID, FirstName, LastName, Department FROM Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("--- Data from SqlDataAdapter ---");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["EmployeeID"]} | {row["FirstName"]} | {row["LastName"]} | {row["Department"]}");
            }
        }
    }

    // 3. NonQuery operation (Insert)
    static void NonQueryOperation()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string insertQuery = "INSERT INTO Employees (EmployeeID, FirstName, LastName, Department) VALUES (20, 'Meera', 'Desai', 'HR')";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Insert failed: " + ex.Message);
            }
        }
    }

    // 4. Parameterized Query operation
    static void ParameterizedQueryOperation()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string insertQuery = "INSERT INTO Employees (EmployeeID, FirstName, LastName, Department) VALUES (@id, @fname, @lname, @dept)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);

            cmd.Parameters.AddWithValue("@id", 21);
            cmd.Parameters.AddWithValue("@fname", "Rohit");
            cmd.Parameters.AddWithValue("@lname", "Patil");
            cmd.Parameters.AddWithValue("@dept", "IT");

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted using parameterized query.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Insert failed: " + ex.Message);
            }
        }
    }

    // 5. Scalar operation
    static void ScalarOperation()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string scalarQuery = "SELECT COUNT(*) FROM Employees";
            SqlCommand cmd = new SqlCommand(scalarQuery, conn);
            int employeeCount = (int)cmd.ExecuteScalar();
            Console.WriteLine($"Total Employees: {employeeCount}");
        }
    }

    // 6. SqlInjection demo 
    static void SqlInjectionOperation()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            Console.Write("Enter FirstName to search: ");
            string userInput = Console.ReadLine();

            string unsafeQuery = "SELECT EmployeeID, FirstName, LastName, Department FROM Employees WHERE FirstName = '" + userInput + "'";
            SqlCommand cmd = new SqlCommand(unsafeQuery, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("--- Results from SqlInjection query ---");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmployeeID"]} | {reader["FirstName"]} | {reader["LastName"]} | {reader["Department"]}");
            }
            reader.Close();
        }
    }
}
