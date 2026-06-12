using StudyAbroadApi.DTOs;
using StudyAbroadApi.Models;
using StudyAbroadApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace StudyAbroadApi.Services;

public interface IUniversityService
{
    Task<List<UniversityResponseDto>> GetAllAsync();
    Task<UniversityResponseDto?> GetByIdAsync(int id);
    Task<UniversityResponseDto> CreateAsync(UniversityCreateDto dto);
    Task<UniversityResponseDto?> UpdateAsync(int id, UniversityUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}

public class UniversityService : IUniversityService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    public UniversityService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<UniversityResponseDto>> GetAllAsync()
    {
        var universities = await _db.Universities.ToListAsync();
        return _mapper.Map<List<UniversityResponseDto>>(universities);
    }

    public async Task<UniversityResponseDto?> GetByIdAsync(int id)
    {
        var u = await _db.Universities.FindAsync(id);
        return u is null ? null : _mapper.Map<UniversityResponseDto>(u);
    }

    public async Task<UniversityResponseDto> CreateAsync(UniversityCreateDto dto)
    {
        var u = _mapper.Map<UniversityCreateDto, University>(dto);
        _db.Universities.Add(u);
        await _db.SaveChangesAsync();
        return _mapper.Map<UniversityResponseDto>(u);
    }

    public async Task<UniversityResponseDto?> UpdateAsync(int id, UniversityUpdateDto dto)
    {
        var u = await _db.Universities.FindAsync(id);
        if (u is null) return null;

        _mapper.Map(dto, u);
        await _db.SaveChangesAsync();
        return _mapper.Map<UniversityResponseDto>(u);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var u = await _db.Universities.FindAsync(id);
        if (u is null) return false;
        _db.Universities.Remove(u);
        await _db.SaveChangesAsync();
        return true;
    }
}
