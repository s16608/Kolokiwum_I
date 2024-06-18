using Kolokiwum_I.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kolokiwum_I.Controllers;

[Route("/api/employees/5")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        string errorMessage;
        bool isDeleted = _employeeRepository.DeleteEmployee(id, out errorMessage);

        if (isDeleted)
        {
            return Ok(new { message = "Pracownik i zadania usunięty pomyślnie" });
        }
        else if (errorMessage == "Nie znaleziono pracownika")
        {
            return NotFound(new { message = errorMessage });
        }
        else
        {
            return StatusCode(500, new { message = "Wystąpił błąd", details = errorMessage });
        }
    }
}