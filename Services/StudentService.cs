using StudyAbroadApi.DTOs;
using StudyAbroadApi.Models;
using StudyAbroadApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace StudyAbroadApi.Services;

public interface IStudentService
{
    Task<List<StudentResponseDto>> GetAllAsync();
    Task<StudentResponseDto?> GetByIdAsync(int id);
    Task<StudentResponseDto> CreateAsync(StudentCreateDto dto);
    Task<StudentResponseDto?> UpdateAsync(int id, StudentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}

public class StudentService : IStudentService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    public StudentService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<StudentResponseDto>> GetAllAsync()
    {
        var students = await _db.Students.ToListAsync();
        return _mapper.Map<List<StudentResponseDto>>(students); 
    }

    public async Task<StudentResponseDto?> GetByIdAsync(int id)
    {
        var s = await _db.Students.FindAsync(id);
        return s is null ? null : _mapper.Map<StudentResponseDto>(s);
    }

    public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
    {
        var student = new Student
        {
            FullName = dto.FullName,
            HighSchool = dto.HighSchool,
            GPA = dto.GPA,
            SATScore = dto.SATScore
        };
        _db.Students.Add(student);
        await _db.SaveChangesAsync();
        return _mapper.Map<StudentResponseDto>(student);
    }

    public async Task<StudentResponseDto?> UpdateAsync(int id, StudentUpdateDto dto)
    {
        var student = await _db.Students.FindAsync(id);
        if (student is null) return null;

        _mapper.Map(dto, student);
        await _db.SaveChangesAsync();
        return _mapper.Map<StudentResponseDto>(student);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student is null) return false;
        _db.Students.Remove(student);
        await _db.SaveChangesAsync();
        return true;
    }
}
