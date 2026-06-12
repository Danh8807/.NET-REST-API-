using StudyAbroadApi.Models;

namespace StudyAbroadApi.Repositories;
public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student> CreateAsync(Student student);
    Task<Student?> UpdateAsync(int id, Student student);
    Task<bool> DeleteAsync(int id);
}