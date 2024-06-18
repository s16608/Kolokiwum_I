namespace Kolokiwum_I.Repositories;

public interface IEmployeeRepository
{
    public bool DeleteEmployee(int employeeId, out string errorMessage);
}