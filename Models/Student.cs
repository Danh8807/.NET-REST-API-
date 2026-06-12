namespace StudyAbroadApi.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string HighSchool { get; set; } = string.Empty;
    public double GPA { get; set; }
    public int SATScore { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
