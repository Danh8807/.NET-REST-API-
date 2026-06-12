using StudyAbroadApi.DTOs;
using StudyAbroadApi.Data;
using Microsoft.EntityFrameworkCore;

namespace StudyAbroadApi.Services;

public interface IRecommendationService
{
    Task<RecommendationResponseDto> GetRecommendationsAsync(RecommendationRequestDto request);
}

public class RecommendationService : IRecommendationService
{
    private readonly AppDbContext _db;

    public RecommendationService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RecommendationResponseDto> GetRecommendationsAsync(RecommendationRequestDto request)
    {
        var matched = await _db.Universities
            .Where(u => u.MinGPA <= request.GPA && u.MinSAT <= request.SATScore)
            .OrderByDescending(u => u.MinGPA)
            .ThenByDescending(u => u.MinSAT)
            .Select(u => new UniversityResponseDto(u.Id, u.Name, u.State, u.AcceptanceRate, u.MinGPA, u.MinSAT, u.Major, u.Tier))
            .ToListAsync();

        return new RecommendationResponseDto(request.FullName, request.GPA, request.SATScore, matched);
    }
}
