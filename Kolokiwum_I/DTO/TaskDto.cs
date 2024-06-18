namespace Kolokiwum_I.DTO;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public int Employee_id { get; set; }
    public int Project_id { get; set; }
    public int Category_id { get; set; }
}