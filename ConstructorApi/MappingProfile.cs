using AutoMapper;
using ConstructorApi.Models;
using ConstructorApi.DTOs.Project;
using ConstructorApi.DTOs.Scene;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectCreateDto, Project>();
        CreateMap<ProjectUpdateDto, Project>();
        CreateMap<ProjectSetting, ProjectSettingDto>();

        CreateMap<Scene, SceneDto>();
        CreateMap<SceneCreateDto, Scene>();
        CreateMap<SceneUpdateDto, Scene>();

        CreateMap<SceneObject, SceneObjectDto>();
        CreateMap<SceneObjectCreateDto, SceneObject>();
    }
}
