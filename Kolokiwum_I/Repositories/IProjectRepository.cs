using Kolokiwum_I.DTO;

namespace Kolokiwum_I.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectDetailsDto>> GetProjectAsync(int IdProject);
}