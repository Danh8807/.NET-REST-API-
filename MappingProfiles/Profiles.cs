using StudyAbroadApi.Models;
using StudyAbroadApi.DTOs;

namespace StudyAbroadApi.MappingProfiles;
public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
        CreateMap<University, UniversityResponseDto>();
        CreateMap<UniversityCreateDto, University>();
        CreateMap<UniversityUpdateDto, University>();

        CreateMap<Student, StudentResponseDto>();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();
        CreateMap<RecommendationRequestDto, Student>();

    }
    
}
