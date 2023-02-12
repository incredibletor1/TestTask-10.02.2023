using TestTask_10._02._2023.Services;


namespace TestTask_10._02._2023.Helpers
{
    // Get all Services from service provider (methods extensions)
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// GetEmployeeService
        /// </summary>
        /// <param name="services"></param>
        /// <returns><see cref="IEmployeeService"/>.</returns>
        public static IEmployeeService EmployeeService(this IServiceProvider services)
        {
            return services.GetService<IEmployeeService>();
        }

        /// <summary>
        /// GetPositionService
        /// </summary>
        /// <param name="services"></param>
        /// <returns><see cref="IPositionService"/>.</returns>
        public static IPositionService PositionService(this IServiceProvider services)
        {
            return services.GetService<IPositionService>();
        }
    }
}
