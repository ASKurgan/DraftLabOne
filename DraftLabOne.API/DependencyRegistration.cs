namespace DraftLabOne.API
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddHandlers();
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
          //  services.AddScoped<PublishProductHandlerApi>();
            return services;
        }
    }
}
