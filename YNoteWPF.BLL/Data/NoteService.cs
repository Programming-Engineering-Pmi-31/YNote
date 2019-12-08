using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using System.Threading.Tasks;
using System.Data.Entity;
using YNoteWPF.BLL.Data.Interfaces;
using YNoteWPF.BLL.Data.Models;
using AutoMapper;
using System.Linq;

namespace YNoteWPF.BLL.Data
{
    public class NoteService : INoteService
    {

        private readonly YNoteDbContext _dbContext;
        private readonly IMapper _mapper;

        public NoteService(YNoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteDTO> CreateNoteAsync(CreateNoteDTO createNoteDTO)
        {
            var noteEntity = _mapper.Map<NoteEntity>(createNoteDTO);
            _dbContext.Notes.Add(noteEntity);
            await _dbContext.SaveChangesAsync();

            noteEntity = await _dbContext.Notes
                .AsNoTracking()
                .Include(note => note.Tasks)
                .SingleOrDefaultAsync(note => note.Id == noteEntity.Id);

            var noteDTO = _mapper.Map<NoteDTO>(noteEntity);
            return noteDTO;
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _dbContext.Notes
                .AsNoTracking()
                .Include(n => n.Tasks)
                .SingleOrDefaultAsync(n => n.Id == id);
            _dbContext.Tasks.RemoveRange(note.Tasks);
            _dbContext.Notes.Remove(note);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<NoteDTO> UpdateNoteAsync(UpdateNoteDTO updateNoteDTO)
        {
            var noteEntity = await _dbContext.Notes
                .Include(n => n.Tasks)
                .SingleOrDefaultAsync(n => n.Id == updateNoteDTO.Id);

            var updateNoteEntity = _mapper.Map<NoteEntity>(updateNoteDTO);

            
            //update note data
            noteEntity.AssignedUserId = updateNoteEntity.AssignedUserId;
            noteEntity.GroupId = updateNoteEntity.GroupId;

            //update tasks data
            if (updateNoteEntity.Tasks != null)
            {
                var tasksToRemove = noteEntity.Tasks.Where(x =>
                   updateNoteEntity.Tasks.All(o => o.Id != x.Id));
                _dbContext.Tasks.RemoveRange(tasksToRemove);
            }
            else
            {
                _dbContext.Tasks.RemoveRange(noteEntity.Tasks);
            }

            await _dbContext.SaveChangesAsync();
            var noteDTO = _mapper.Map<NoteDTO>( noteEntity);

            return noteDTO;

        }

        public async Task<List<NoteDTO>> GetAllNotesAsync()
        {
            var noteEntity = await _dbContext.Notes
                .AsNoTracking()
                .ToListAsync();

            var noteDTO = _mapper.Map<List<NoteDTO>>(noteEntity);
            return noteDTO;
        }
    }
}
