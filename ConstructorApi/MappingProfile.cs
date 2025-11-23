using AutoMapper;
using ConstructorApi.Models;
using ConstructorApi.DTOs.Project;
using ConstructorApi.DTOs.Scene;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.Settings))
            .ForMember(dest => dest.Scenes, opt => opt.MapFrom(src => src.Scenes));

        CreateMap<ProjectCreateDto, Project>()
            .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.Settings));

        CreateMap<ProjectUpdateDto, Project>()
            .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.Settings));

        CreateMap<ProjectSetting, ProjectSettingDto>().ReverseMap();

        CreateMap<Scene, SceneDto>();
        CreateMap<SceneCreateDto, Scene>();
        CreateMap<SceneUpdateDto, Scene>();

        CreateMap<SceneObject, SceneObjectDto>();
        CreateMap<SceneObjectCreateDto, SceneObject>();
    }
}
