using StudyAbroadApi.Data;
using StudyAbroadApi.Models;
using Microsoft.EntityFrameworkCore;
namespace StudyAbroadApi.Repositories;
public class UniversityRepository : IUniversityRepository
{
    private readonly AppDbContext _db;
    public UniversityRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<University>> GetAllAsync()
    {
        return await _db.Universities.ToListAsync();
    }

    public async Task<University?> GetByIdAsync(int id)
    {
        return await _db.Universities.FindAsync(id);
    }

    public async Task<University> CreateAsync(University university)
    {
        _db.Universities.Add(university);
        await _db.SaveChangesAsync();
        return university;
    }

    public async Task<University?> UpdateAsync(int id, University university)
    {
        var u = await _db.Universities.FindAsync(id);
        if (u is null) return null;

        u.Name = university.Name;
        u.State = university.State;
        u.AcceptanceRate = university.AcceptanceRate;
        u.MinGPA = university.MinGPA;
        u.MinSAT = university.MinSAT;
        u.Major = university.Major;
        u.Tier = university.Tier;
        await _db.SaveChangesAsync();
        return u;
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