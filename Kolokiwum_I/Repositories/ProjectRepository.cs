using System.Data.SqlClient;
using Kolokiwum_I.DTO;

namespace Kolokiwum_I.Repositories;

public class ProjectRepository : IProjectRepository
{
    
    private readonly string _connectionString;
    
    public ProjectRepository(IConfiguration configuration)
    {
        _connectionString = configuration["DefaultConnection"] ?? throw new ArgumentException("Brak podanego connection stringa do bazy!");
    }
    
    
    public async Task<IEnumerable<ProjectDetailsDto>> GetProjectAsync(int IdProject)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        var query = "SELECT p.Id AS ProjectId, p.Name AS ProjectName, p.Description AS ProjectDescription, p.StartDate AS ProjectStartDate, p.EndDate AS ProjectEndDate, t.Id AS TaskId, t.Title AS TaskTitle, t.Description AS TaskDescription, t.DueDate AS TaskDueDate, t.Status AS TaskStatus, c.Id AS CategoryId, c.Name AS CategoryName, c.Description AS CategoryDescription FROM Project p LEFT JOIN Task t ON p.Id = t.Project_Id LEFT JOIN Category c ON t.Category_Id = c.Id WHERE p.Id = @projectId ORDER BY t.DueDate DESC;";
        
        await using var command = new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@projectId", IdProject);
        
        var reader = await command.ExecuteReaderAsync();
        
        List<ProjectDetailsDto> projectDetailsDtos = [];

        while (reader.Read())
        {
            var dto = new ProjectDetailsDto()
            {
              
            };

            projectDetailsDtos.Add(dto);
        }

        return projectDetailsDtos;
    }
}