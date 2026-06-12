using StudyAbroadApi.Models;
using StudyAbroadApi.Data;
using Microsoft.EntityFrameworkCore;

namespace StudyAbroadApi.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _db;
    public StudentRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _db.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _db.Students.FindAsync(id);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        _db.Students.Add(student);
        await _db.SaveChangesAsync();
        return student;
    }

    public async Task<Student?> UpdateAsync(int id, Student student)
    {
        var s = await _db.Students.FindAsync(id);
        if (s is null) return null;

        s.FullName = student.FullName;
        s.HighSchool = student.HighSchool;
        s.GPA = student.GPA;
        s.SATScore = student.SATScore;
        await _db.SaveChangesAsync();
        return s;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var s = await _db.Students.FindAsync(id);
        if (s is null) return false;

        _db.Students.Remove(s);
        await _db.SaveChangesAsync();
        return true;
    }
}