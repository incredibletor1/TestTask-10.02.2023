using Microsoft.AspNetCore.Mvc;
using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Models.VM;
using TestTask_10._02._2023.Services;

namespace TestTask_10._02._2023.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        /// <summary>
        /// Defines the IPositionService
        /// </summary>
        private readonly IPositionService positionService;

        /// <summary>
        /// Defines the logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionController"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider<see cref="IServiceProvider"/>.</param>
        /// <param name="logger">Logger<see cref="ILogger"/>.</param>
        public PositionController(IServiceProvider serviceProvider, ILogger<PositionController> logger)
        {
            positionService = serviceProvider.PositionService();
            _logger = logger;
        }

        /// <summary>
        /// Get Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns><see cref="PositionVM"/>.</returns>
        [HttpGet]
        [Route("{positionId}")]
        public async Task<IActionResult> GetPositionByIdAsync(int positionId)
        {
            var positionDto = await positionService.GetPositionByIdAsync(positionId);

            return Ok(positionDto.ToVM());
        }

        /// <summary>
        /// Create or Update Position
        /// </summary>
        /// <param name="positionVM"></param>
        /// <returns><see cref="PositionVM"/>.</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOrUpdatePositionAsync(PositionVM positionVM)
        {
            var positionDto = await positionService.CreateOrUpdatePositionAsync(positionVM);

            return Ok(positionDto.ToVM());
        }

        /// <summary>
        /// Delete Position by Id
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{positionId}")]
        public async Task<IActionResult> DeletePositionByIdAsync(int positionId)
        {
            await positionService.DeletePositionByIdAsync(positionId);

            return Ok();
        }
    }
}
