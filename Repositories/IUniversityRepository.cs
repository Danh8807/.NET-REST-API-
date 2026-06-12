using StudyAbroadApi.Models;

namespace StudyAbroadApi.Repositories;

public interface IUniversityRepository
{
    Task<List<University>> GetAllAsync();
    Task<University?> GetByIdAsync(int id);
    Task<University> CreateAsync(University university);
    Task<University?> UpdateAsync(int id, University university);
    Task<bool> DeleteAsync(int id);
}