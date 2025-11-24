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

        CreateMap<Scene, SceneExportDto>()
            .ForMember(dest => dest.SceneName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Objects, opt => opt.MapFrom(src => src.Objects));

        CreateMap<SceneExportDto, Scene>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SceneName))
            .ForMember(dest => dest.Objects, opt => opt.MapFrom(src => src.Objects));

        CreateMap<SceneObjectDto, SceneObject>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.PositionX, opt => opt.MapFrom(src => src.PositionX))
            .ForMember(dest => dest.PositionY, opt => opt.MapFrom(src => src.PositionY))
            .ForMember(dest => dest.PositionZ, opt => opt.MapFrom(src => src.PositionZ))
            .ForMember(dest => dest.RotationX, opt => opt.MapFrom(src => src.RotationX))
            .ForMember(dest => dest.RotationY, opt => opt.MapFrom(src => src.RotationY))
            .ForMember(dest => dest.RotationZ, opt => opt.MapFrom(src => src.RotationZ))
            .ForMember(dest => dest.ScaleX, opt => opt.MapFrom(src => src.ScaleX))
            .ForMember(dest => dest.ScaleY, opt => opt.MapFrom(src => src.ScaleY))
            .ForMember(dest => dest.ScaleZ, opt => opt.MapFrom(src => src.ScaleZ))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.TextureId, opt => opt.MapFrom(src => src.TextureId.ToString()))
            .ForMember(dest => dest.Params, opt => opt.MapFrom(src => src.Params));

         CreateMap<SceneObject, SceneObjectDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.PositionX, opt => opt.MapFrom(src => src.PositionX))
            .ForMember(dest => dest.PositionY, opt => opt.MapFrom(src => src.PositionY))
            .ForMember(dest => dest.PositionZ, opt => opt.MapFrom(src => src.PositionZ))
            .ForMember(dest => dest.RotationX, opt => opt.MapFrom(src => src.RotationX))
            .ForMember(dest => dest.RotationY, opt => opt.MapFrom(src => src.RotationY))
            .ForMember(dest => dest.RotationZ, opt => opt.MapFrom(src => src.RotationZ))
            .ForMember(dest => dest.ScaleX, opt => opt.MapFrom(src => src.ScaleX))
            .ForMember(dest => dest.ScaleY, opt => opt.MapFrom(src => src.ScaleY))
            .ForMember(dest => dest.ScaleZ, opt => opt.MapFrom(src => src.ScaleZ))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.TextureId, opt => opt.MapFrom(src => src.TextureId))
            .ForMember(dest => dest.Params, opt => opt.MapFrom(src => src.Params));
    }
}
