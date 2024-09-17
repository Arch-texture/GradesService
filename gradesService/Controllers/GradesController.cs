using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly GradesDbContext _context;

    public GradesController(GradesDbContext context)
    {
        _context = context;
    }

    //Asignar nueva calificación a un estudiante
    [HttpPost]
    public async Task<IActionResult> AssignGrade([FromBody] GradeDto newGrade)
    {
        var grade = new Grade
        {
            GradeId = Guid.NewGuid(),
            StudentId = newGrade.StudentId,
            SubjectName = newGrade.SubjectName,
            GradeName = newGrade.GradeName,
            Value = newGrade.Value,
            Comment = newGrade.Comment
        };

        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();

        return Ok(grade);
    }

    //Actualizar calificación existente
    [HttpPut("{gradeId}/{studentId}")]
    public async Task<IActionResult> UpdateGrade(Guid gradeId, Guid studentId, [FromBody] UpdateDto newGrade)
    {
         var grade = await _context.Grades
        .Where(g => g.GradeId == gradeId && g.StudentId == studentId)
        .FirstOrDefaultAsync();

        if (grade == null)
            return NotFound();

        grade.SubjectName = newGrade.SubjectName;
        grade.GradeName = newGrade.GradeName;
        grade.Value = newGrade.Value;
        grade.Comment = newGrade.Comment;

        await _context.SaveChangesAsync();

        return Ok(grade);
    }
}
