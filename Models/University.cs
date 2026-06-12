namespace StudyAbroadApi.Models;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string AcceptanceRate { get; set; } = string.Empty;
    public double MinGPA { get; set; }
    public int MinSAT { get; set; }
    public string Major { get; set; } = string.Empty;
    public string Tier { get; set; } = string.Empty;
}
