namespace Kolokiwum_I.Repositories;

using System;
using System.Data.SqlClient;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;
    
    public EmployeeRepository(IConfiguration configuration)
    {
        _connectionString = configuration["DefaultConnection"] ?? throw new ArgumentException("Brak podanego connection stringa do bazy!");
    }

    public bool DeleteEmployee(int employeeId, out string errorMessage)
    {
        errorMessage = null;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Task WHERE Employee_Id = @EmployeeId", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.ExecuteNonQuery();
                }
                
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE Id = @EmployeeId", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        transaction.Rollback();
                        errorMessage = "Employee not found";
                        return false;
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
