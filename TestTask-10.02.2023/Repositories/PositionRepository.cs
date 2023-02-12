using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Exceptions;
using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.Context;
using TestTask_10._02._2023.Models.DTO;

namespace TestTask_10._02._2023.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        /// <summary>
        /// Defines DB context.
        /// </summary>
        private readonly ITestTaskDbContext _testTaskDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionRepository"/> class.
        /// </summary>
        /// <param name="testTaskDbContext">DB Context<see cref="ITestTaskDbContext"/>.</param>
        /// <param name="mapper">AutoMapper<see cref="IMapper"/>.</param>
        public PositionRepository(ITestTaskDbContext testTaskDbContext, IMapper mapper)
        {
            this._testTaskDbContext = testTaskDbContext;
            ConversionExtension.InitMapper(mapper);
        }

        /// <summary>
        /// Get Position Entity by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns><see cref="Position"/>.</returns>
        private async Task<Position?> GetPositionEntityByIdAsync(int positionId)
        {
            var position = await _testTaskDbContext.Positions
                .Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.Id == positionId);
            
            return position;
        }

        /// <summary>
        /// Get Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns><see cref="PositionDto"/>.</returns>
        public async Task<PositionDto?> GetPositionByIdAsync(int positionId)
        {
            var position = await GetPositionEntityByIdAsync(positionId);

            return position?.ToDto();
        }

        /// <summary>
        /// Get Positions collection by ids
        /// </summary>
        /// <param name="positionsIds"></param>
        /// <returns><see cref="List{Position}"/>.</returns>
        public async Task<List<Position>> GetPositionsListByIdAsync(List<int> positionsIds)
        {
            var positions = await _testTaskDbContext.Positions
                .Where(p => positionsIds.Contains(p.Id))
                .ToListAsync();

            return positions;
        }

        /// <summary>
        /// Create Position
        /// </summary>
        /// <param name="positionDto"></param>
        /// <returns><see cref="PositionDto"/>.</returns>
        public async Task<PositionDto> CreatePositionAsync(PositionDto positionDto)
        {
            var position = await _testTaskDbContext.Positions.AddAsync(positionDto.ToEntity());
            await _testTaskDbContext.SaveChangesAsync();

            return position.Entity.ToDto();
        }

        /// <summary>
        /// Delete Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task DeletePositionByIdAsync(int positionId)
        {
            var position = await GetPositionEntityByIdAsync(positionId);

            if (position is null)
                throw new ArgumentException($"no Position with id {positionId}");
            if (position.Employees.Any())
                throw new CannotBeDeletedException("cannot delete a Position that already has employees");

            _testTaskDbContext.Positions.Remove(position);
            await _testTaskDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update Position
        /// </summary>
        /// <param name="positionDto"></param>
        /// <returns><see cref="PositionDto"/>.</returns>
        public async Task<PositionDto> UpdatePositionAsync(PositionDto positionDto)
        {
            var position = await GetPositionEntityByIdAsync(positionDto.Id);

            if (position is null)
                throw new ArgumentException($"no Position with id {positionDto.Id}");

            position.Name = positionDto.Name;
            position.Grade = positionDto.Grade;

            await _testTaskDbContext.SaveChangesAsync();

            return position.ToDto();
        }
    }
}
