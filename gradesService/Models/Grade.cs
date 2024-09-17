using System;

public class Grade
{
    public Guid GradeId { get; set; } 
    public Guid StudentId { get; set; } 
    public string SubjectName { get; set; } = string.Empty; 
    public string GradeName { get; set; } =  string.Empty;  
    public double Value { get; set; } 
    public string Comment { get; set; } = string.Empty; 
}
