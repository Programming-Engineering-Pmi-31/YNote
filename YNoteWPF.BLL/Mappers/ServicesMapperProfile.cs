using AutoMapper;
using YNoteWPF.BLL.Data.Models;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Mappers
{
    class ServicesMapperProfile: Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<CreateTaskDTO, TaskEntity>();
            CreateMap<TaskEntity, TaskDTO>();
            CreateMap<UpdateTaskDTO, TaskEntity>();
            CreateMap<UpdateTaskDTO, CreateTaskDTO>();
        }
    }
}