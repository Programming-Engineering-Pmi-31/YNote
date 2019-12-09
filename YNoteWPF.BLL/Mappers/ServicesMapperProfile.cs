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
            //CreateMap<UpdateTaskDTO, CreateTaskDTO>();

            CreateMap<CreateNoteDTO, NoteEntity>();
            CreateMap<NoteEntity, NoteDTO>();
            CreateMap<UpdateNoteDTO, NoteEntity>();

            CreateMap<CreateSpaceDTO, SpaceDTO>();
            CreateMap<SpaceEntity, SpaceDTO>();
            CreateMap<UpdateSpaceDTO, SpaceEntity>();
        }
    }
}