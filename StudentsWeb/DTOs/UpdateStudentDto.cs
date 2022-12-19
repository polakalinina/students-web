namespace StudentsWeb.DTOs;

public class UpdateStudentDto
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public string LastName { get; set; }
    
    public string Group { get; set; }
}