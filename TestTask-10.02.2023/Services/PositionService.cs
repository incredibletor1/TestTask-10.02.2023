using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models.VM;
using TestTask_10._02._2023.Repositories;

namespace TestTask_10._02._2023.Services
{
    public class PositionService : IPositionService
    {
        /// <summary>
        /// Defines the services.
        /// </summary>
        private readonly IPositionRepository positionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider<see cref="IServiceProvider"/>.</param>
        public PositionService(IServiceProvider serviceProvider)
        {
            positionRepository = serviceProvider.PositionRepository();
        }

        /// <summary>
        /// Get Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns><see cref="PositionDto"/>.</returns>
        public async Task<PositionDto> GetPositionByIdAsync(int positionId)
        {
            var position = await positionRepository.GetPositionByIdAsync(positionId);

            if (position is null)
                throw new ArgumentException($"no Position with id {positionId}");

            return position;
        }

        /// <summary>
        /// Get Positions collection by ids
        /// </summary>
        /// <param name="positionsIds"></param>
        /// <returns><see cref="List{Position}"/>.</returns>
        public async Task<List<Position>> GetPositionsListByIdAsync(List<int> positionsIds)
        {
            var positionsList = await positionRepository.GetPositionsListByIdAsync(positionsIds);
            var positionsThatNotExist = positionsIds.Except(positionsList.Select(position => position.Id));
            if (positionsThatNotExist.Any())
                throw new ArgumentException("no position with id : "+ $"{string.Join(",", positionsThatNotExist.Select(pos => pos))}");

            return positionsList;
        }

        /// <summary>
        /// Create or Update Position
        /// </summary>
        /// <param name="positionVM"></param>
        /// <returns><see cref="PositionDto"/>.</returns>
        public async Task<PositionDto> CreateOrUpdatePositionAsync(PositionVM positionVM)
        {
            if (await positionRepository.GetPositionByIdAsync(positionVM.Id) is null)
            {
                return await positionRepository.CreatePositionAsync(positionVM.ToDto());
            }
            else
            {
                return await positionRepository.UpdatePositionAsync(positionVM.ToDto());
            }
        }

        /// <summary>
        /// Delete Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public async Task DeletePositionByIdAsync(int positionId)
        {
            await positionRepository.DeletePositionByIdAsync(positionId);
        }
    }
}
