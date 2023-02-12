using TestTask_10._02._2023.Repositories;

namespace TestTask_10._02._2023.Helpers
{
    // Get all Repositories from service provider (methods extensions)
    public static class RepositoryProviderExtensions
    {
        /// <summary>
        /// GetEmployeeRepository.
        /// </summary>
        /// <param name="services"></param>
        /// <returns><see cref="IEmployeeRepository"/>.</returns>
        public static IEmployeeRepository EmployeeRepository(this IServiceProvider services)
        {
            return services.GetService<IEmployeeRepository>();
        }

        /// <summary>
        /// GetPositionRepository.
        /// </summary>
        /// <param name="services"></param>
        /// <returns><see cref="IPositionRepository"/>.</returns>
        public static IPositionRepository PositionRepository(this IServiceProvider services)
        {
            return services.GetService<IPositionRepository>();
        }
    }
}
