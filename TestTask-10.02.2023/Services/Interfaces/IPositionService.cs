using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models.VM;


namespace TestTask_10._02._2023.Services
{ 
    public interface IPositionService
    {
        Task<PositionDto> GetPositionByIdAsync(int positionId);
        Task<List<Position>> GetPositionsListByIdAsync(List<int> positionsIds);
        Task<PositionDto> CreateOrUpdatePositionAsync(PositionVM positionVM);
        Task DeletePositionByIdAsync(int positionId);
    }
}
