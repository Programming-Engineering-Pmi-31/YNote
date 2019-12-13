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
    /// <summary>
    /// Service to operate Spaces
    /// </summary>
    public class SpaceService : ISpaceService
    {
        private readonly YNoteDbContext _dbContext;
        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceService"/> class.
        /// </summary>
        /// <param name="dbContext">Database context injection.</param>
        /// <param name="mapper">Mapper injection.</param>
        public SpaceService(YNoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheridoc/>
        public async Task<SpaceDTO> CreateSpaceAsync(CreateSpaceDTO createSpaceDTO)
        {
            var spaceEntity = _mapper.Map<SpaceEntity>(createSpaceDTO);

            _dbContext.Spaces.Add(spaceEntity);
            await _dbContext.SaveChangesAsync();

            spaceEntity = await _dbContext.Spaces
                .AsNoTracking()
                .SingleOrDefaultAsync(space => space.Id == spaceEntity.Id);

            var spaceDTO = _mapper.Map<SpaceDTO>(spaceEntity);
            return spaceDTO;
                
        }

        /// <inheridoc/>
        public async Task DeleteSpaceAsync(int id)
        {
            var spaceToDelete = await _dbContext.Spaces
                .AsNoTracking()
                .Include(space => space.Groups)
                .Include(space => space.Notes.Select(n => n.Tasks))
                .SingleOrDefaultAsync(space => space.Id == id);

            //remove all that space contains
            _dbContext.Groups.RemoveRange(spaceToDelete.Groups);
            await _dbContext.Notes.ForEachAsync(n=>_dbContext.Tasks.RemoveRange(n.Tasks));
            _dbContext.Notes.RemoveRange(spaceToDelete.Notes);

            _dbContext.Spaces.Remove(spaceToDelete);

            await _dbContext.SaveChangesAsync();            
        }

        /// <inheridoc/>
        public async Task<List<SpaceDTO>> GetAllSpacesAsync()
        {
            var spaceEntity = await _dbContext.Spaces
                .AsNoTracking()
                .Include(space => space.Groups)
                .Include(space => space.Notes.Select(n=>n.Tasks))
                .Include(space => space.Users)
                .ToListAsync();

            var spaceDTO = _mapper.Map<List<SpaceDTO>>(spaceEntity);
            return spaceDTO;
        }

        /// <inheridoc/>
        public async Task<SpaceDTO> GetSpaceByIdAsync(int id)
        {
            var spaceEntity = await _dbContext.Spaces
                .AsNoTracking()
                .Include(space => space.Groups)
                .Include(space => space.Notes.Select(n => n.Tasks))                
                .Include(space=> space.Users)
                .SingleOrDefaultAsync(space => space.Id == id);

            var spaceDTO = _mapper.Map<SpaceDTO>(spaceEntity);
            return spaceDTO;
        }

        /// <inheridoc/>
        public async Task<SpaceDTO> ChangeSpaceNameAsync(UpdateSpaceDTO updateSpaceDTO)
        {

            var spaceEntity = await _dbContext.Spaces
                .AsNoTracking()
                //.Include(space => space.Groups)
                //.Include(space => space.Notes.Select(n => n.Tasks))
                //.Include(space => space.Users)
                .SingleOrDefaultAsync(space => space.Id == updateSpaceDTO.Id);

            var updateSpaceEntity = _mapper.Map<SpaceEntity>(updateSpaceDTO);
            spaceEntity.SpaceName = updateSpaceEntity.SpaceName;

            await _dbContext.SaveChangesAsync();

            var spaceDTO = _mapper.Map<SpaceDTO>(spaceEntity);

            return spaceDTO;

        }

        public Task<SpaceDTO> UpdateSpaceUsersAsync(UpdateSpaceDTO updateSpaceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
