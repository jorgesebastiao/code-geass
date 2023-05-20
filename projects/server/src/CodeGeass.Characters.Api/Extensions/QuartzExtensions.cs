
using CodeGeass.Characters.Api.Jobs;
using Quartz;

namespace CodeGeass.Characters.Api.Extensions
{
    /// <summary>
    /// Classe de extensão responsavel pelas configurações do Quartz
    /// </summary>
    public static class QuartzExtensions
    {
        /// <summary>
        /// Método de extensão responsavel por configurar o Quartz
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(options =>
            {
                options.SchedulerId = "CodeGeass-customers-api";
                options.UseMicrosoftDependencyInjectionJobFactory();

                options.UseSimpleTypeLoader();
                options.UseInMemoryStore();

                options.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 2;
                });

                options.UseTimeZoneConverter();
                options.AddJob<IntegrationEventPublisherJob>(opts => opts
                .StoreDurably()
                .WithIdentity(nameof(IntegrationEventPublisherJob))
                .Build());

                options.AddTrigger(opts => opts
                        .WithIdentity($"{nameof(IntegrationEventPublisherJob)}Trigger")
                        .ForJob(nameof(IntegrationEventPublisherJob))
                        .StartNow()
                        .WithCronSchedule("0/1 * * ? * *"));
            });

            services.AddTransient<IntegrationEventPublisherJob>();

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
