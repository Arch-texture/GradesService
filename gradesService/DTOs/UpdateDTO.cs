using System.ComponentModel.DataAnnotations;
public class UpdateDto
{
    [Required]
    public string SubjectName { get; set; } = string.Empty;
    [Required] 
    public string GradeName { get; set; } = string.Empty;
    [Required] 
    public double Value { get; set; }
    [Required] 
    public string Comment { get; set; } = string.Empty; 
}
