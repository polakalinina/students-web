using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsWeb.DTOs;
using StudentsWeb.Entities;

namespace StudentsWeb.Pages.Students;

[Authorize]
public class Index : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public Index(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Student> Students { get; set; }

    public async Task<IActionResult> OnGet()
    {
        Students = await _dbContext.Students.ToListAsync();

        return Page();
    }
    
    public async Task<IActionResult> OnPostStudent(CreateStudentDto dto)
    {
        var student = new Student
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Group = dto.Group
        };
        
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();

        return RedirectToPage();
    }
    
    public async Task<IActionResult> OnPostUpdateStudent(UpdateStudentDto dto)
    {
        var student = await _dbContext.Students.FirstAsync(student => student.Id == dto.Id);

        student.FirstName = dto.FirstName;
        student.MiddleName = dto.MiddleName;
        student.LastName = dto.LastName;
        student.Group = dto.Group;

        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync();

        return RedirectToPage();
    }
    
    public async Task<IActionResult> OnPostDeleteStudent(int id)
    {
        var student = await _dbContext.Students.FirstAsync(student => student.Id == id);

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();

        return RedirectToPage();
    }
}