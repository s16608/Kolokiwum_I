using Microsoft.VisualBasic;

namespace Kolokiwum_I.DTO;

public class ProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndtDate { get; set; }
    
    
}