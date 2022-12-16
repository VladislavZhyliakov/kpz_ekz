using AutoMapper;
using DTOs.StudentDTOs;
using Domain.Entities;
using Domain.Enums;
using DTOs.UniTaskDTOs;

namespace Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<Student, DetailedStudentDTO>()
                .ForMember(x => x.UniTasks, g => g.MapFrom(e => e.StudentUniTasks));
            CreateMap<StudentUniTask, UniTaskDTO>()
                .ForMember(x => x.Description, g => g.MapFrom(e => e.UniTask==null?null:e.UniTask.Description))
                .ForMember(x => x.TaskDate, g => g.MapFrom(e => e.UniTask == null ? null : e.UniTask.TaskDate))
                .ForMember(x => x.Priority, g => g.MapFrom(e => e.UniTask == null ? null : e.UniTask.Priority))
                .ForMember(x => x.Status, g => g.MapFrom(e => e.UniTask == null ? null : e.UniTask.Status));

            CreateMap<StudentTasksDTO, StudentUniTask>();


        }
    }
}
