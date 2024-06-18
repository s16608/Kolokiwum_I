using Kolokiwum_I.DTO;
using Kolokiwum_I.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kolokiwum_I.Controllers;


[Route("/api/projects/5")]
[ApiController]
public class ProjectController : ControllerBase
{
    
    private readonly IProjectRepository _projectRepository;

    public ProjectController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDetailsDto>>> Browse(int IdProject)
        => Ok(await _projectRepository.GetProjectAsync(IdProject));
}