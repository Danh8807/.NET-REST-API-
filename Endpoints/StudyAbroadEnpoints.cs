using Microsoft.EntityFrameworkCore;
using StudyAbroadApi.DTOs;
using StudyAbroadApi.Services;

namespace StudyAbroadApi.Endpoints;

public static class StudyAbroadEndpoints
{
    public static void MapStudyAbroadEndpoints(this WebApplication app)
    {
        var students = app.MapGroup("/api/students").RequireAuthorization();

        students.MapGet("/", async (IStudentService svc) =>
            Results.Ok(await svc.GetAllAsync()));

        students.MapGet("/{id:int}", async (int id, IStudentService svc) =>
            await svc.GetByIdAsync(id) is { } student
                ? Results.Ok(student)
                : Results.NotFound());

        students.MapPost("/", async (StudentCreateDto dto, IStudentService svc) =>
        {
            var created = await svc.CreateAsync(dto);
            return Results.Created($"/api/students/{created.Id}", created);
        });

        students.MapPut("/{id:int}", async (int id, StudentUpdateDto dto, IStudentService svc) =>
            await svc.UpdateAsync(id, dto) is { } updated
                ? Results.Ok(updated)
                : Results.NotFound());

        students.MapDelete("/{id:int}", async (int id, IStudentService svc) =>
            await svc.DeleteAsync(id)
                ? Results.NoContent()
                : Results.NotFound());

        var universities = app.MapGroup("/api/universities").RequireAuthorization();

        universities.MapGet("/", async (IUniversityService svc) =>
            Results.Ok(await svc.GetAllAsync()));

        universities.MapGet("/{id:int}", async (int id, IUniversityService svc) =>
            await svc.GetByIdAsync(id) is { } u
                ? Results.Ok(u)
                : Results.NotFound());

        universities.MapPost("/", async (UniversityCreateDto dto, IUniversityService svc) =>
        {
            var created = await svc.CreateAsync(dto);
            return Results.Created($"/api/universities/{created.Id}", created);
        });

        universities.MapPut("/{id:int}", async (int id, UniversityUpdateDto dto, IUniversityService svc) =>
            await svc.UpdateAsync(id, dto) is { } updated
                ? Results.Ok(updated)
                : Results.NotFound());

        universities.MapDelete("/{id:int}", async (int id, IUniversityService svc) =>
            await svc.DeleteAsync(id)
                ? Results.NoContent()
                : Results.NotFound());
    }
}