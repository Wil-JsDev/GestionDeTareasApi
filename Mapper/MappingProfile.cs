using AutoMapper;
using GestionDeTareasApi.DTos;
using GestionDeTareasApi.Models;

namespace GestionDeTareasApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskDtos, TaskItem>()
                    .ForMember(dest => dest.Description, src => src.MapFrom(x => x.DescriptionAboutTask))
                    .ForMember(src => src.Status, dest => dest.MapFrom(x => x.StatusTask));

            CreateMap<TaskItem, TaskDtos>();
            CreateMap<UpdateTaskDtos, TaskItem>();
        }
    }
}
