namespace StudyAbroadApi.DTOs;

public record StudentCreateDto(
    string FullName,
    string HighSchool,
    double GPA,
    int SATScore
);

public record StudentUpdateDto(
    string FullName,
    string HighSchool,
    double GPA,
    int SATScore
);

public record StudentResponseDto(
    int Id,
    string FullName,
    string HighSchool,
    double GPA,
    int SATScore,
    DateTime CreatedAt
);

public record UniversityCreateDto(
    string Name,
    string State,
    string AcceptanceRate,
    double MinGPA,
    int MinSAT,
    string Major,
    string Tier
);

public record UniversityUpdateDto(
    string Name,
    string State,
    string AcceptanceRate,
    double MinGPA,
    int MinSAT,
    string Major,
    string Tier
);

public record UniversityResponseDto(
    int Id,
    string Name,
    string State,
    string AcceptanceRate,
    double MinGPA,
    int MinSAT,
    string Major,
    string Tier
);

public record RecommendationRequestDto(
    string FullName,
    string HighSchool,
    double GPA,
    int SATScore
);

public record RecommendationResponseDto(
    string StudentName,
    double GPA,
    int SATScore,
    List<UniversityResponseDto> RecommendedUniversities
);
