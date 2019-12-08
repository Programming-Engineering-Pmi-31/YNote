using AutoMapper;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.BLL.Data.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using YNoteWPF.BLL.Data.Interfaces;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Data
{
    public class TaskService : ITaskService
    {
        private readonly YNoteDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(YNoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskDTO> CreateTaskAsync(CreateTaskDTO createTaskDTO)
        {
            var taskEntity = _mapper.Map<TaskEntity>(createTaskDTO);
            _dbContext.Tasks.Add(taskEntity);
            await _dbContext.SaveChangesAsync();

            taskEntity = await _dbContext.Tasks
                .AsNoTracking()
                .SingleOrDefaultAsync(task => task.Id == taskEntity.Id);

            var taskDTO = _mapper.Map<TaskDTO>(taskEntity);

            return taskDTO;

        }

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var taskEntity = await _dbContext.Tasks
                .AsNoTracking()
                .ToListAsync();

            var taskDTO = _mapper.Map<List<TaskDTO>>(taskEntity);
            return taskDTO;
        }

        public async Task<TaskDTO> UpdateTaskAsync(UpdateTaskDTO updateTaskDTO)
        {
            var taskEntity = await _dbContext.Tasks
                .SingleOrDefaultAsync(task => task.Id == updateTaskDTO.Id);

            var updateTaskEntity = _mapper.Map<TaskEntity>(updateTaskDTO);

            

            taskEntity.SumUp = updateTaskEntity.SumUp;
            taskEntity.Description = updateTaskEntity.Description;
            taskEntity.Status = updateTaskEntity.Status;

            var taskDTO = _mapper.Map<TaskDTO>(taskEntity);

            return taskDTO;
        }
    }
}
