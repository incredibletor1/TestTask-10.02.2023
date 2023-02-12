using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;

namespace TestTask_10._02._2023.Repositories
{
    public interface IPositionRepository
    {
        Task<PositionDto?> GetPositionByIdAsync(int positionId);
        Task<List<Position>> GetPositionsListByIdAsync(List<int> positionsIds);
        Task<PositionDto> CreatePositionAsync(PositionDto positionDto);
        Task DeletePositionByIdAsync(int positionId);
        Task<PositionDto> UpdatePositionAsync(PositionDto positionDto);
    }
}
