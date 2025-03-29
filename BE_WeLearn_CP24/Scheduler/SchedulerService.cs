using API.Scheduler.Jobs;
using API.Scheduler.Lib;
using APIExtension.Scheduler.Jobs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Utilities.ServiceExtensions.Scheduler.Jobs;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace Utilities.ServiceExtensions.Scheduler;

public static class SchedulerService
{
    public static IServiceCollection AddSchedulerService(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        //services.AddHostedService<QuarztHostedService>();
        //services.AddSingleton<IJobFactory, CustomeJobFactory>();
        //services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        ////if (environment.IsDevelopment())
        //if (environment.IsProduction() || environment.IsDevelopment())
        //{
        //    services.AddSingleton<DailyJob>();
        //    services.AddSingleton<WeeklyJob>();
        //    services.AddSingleton<EndMonthlyJob>();
        //    services.AddSingleton(new ScheduledJob(typeof(DailyJob), DailyJob.schedule));
        //    services.AddSingleton(new ScheduledJob(typeof(WeeklyJob), WeeklyJob.schedule));
        //    services.AddSingleton(new ScheduledJob(typeof(EndMonthlyJob), EndMonthlyJob.schedule));
        //}
        ////easy testing
        //if (environment.IsDevelopment())
        //{
        //    services.AddSingleton<ThirtySecondJob>();
        //    services.AddSingleton(new ScheduledJob(typeof(ThirtySecondJob), ThirtySecondJob.schedule));
        //    services.AddSingleton<EmailReminderJob>();

        //    services.AddScoped<ICustomQuarztHostedService, QuarztHostedService>();

        //    // DO NOT ADD: will manually add EmailReminderJob later
        //    //services.AddSingleton(new ScheduledJob(typeof(EmailReminderJob), ThirtySecondJob.schedule));  
        //}

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();

            if (environment.IsProduction() || environment.IsDevelopment())
            {
                //    services.AddSingleton<DailyJob>();
                //    services.AddSingleton(new ScheduledJob(typeof(DailyJob), DailyJob.schedule));
                //    services.AddSingleton<WeeklyJob>();
                //    services.AddSingleton(new ScheduledJob(typeof(WeeklyJob), WeeklyJob.schedule));
                //    services.AddSingleton<EndMonthlyJob>();
                //    services.AddSingleton(new ScheduledJob(typeof(EndMonthlyJob), EndMonthlyJob.schedule));
            }
            if (environment.IsDevelopment())
            {
                //    services.AddSingleton<ThirtySecondJob>();
                //    services.AddSingleton(new ScheduledJob(typeof(ThirtySecondJob), ThirtySecondJob.schedule));
                q.AddJobAndTrigger<ThirtySecondJob>(ThirtySecondJob.schedule);
            }

        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        return services;
    }
    private static IServiceCollectionQuartzConfigurator AddJobAndTrigger<T>(
        this IServiceCollectionQuartzConfigurator q, string cronFormat) where T : IJob
    {
        var jobKey = new JobKey(typeof(T).FullName);

        // Register the job with the DI container
        q.AddJob<T>(opts => opts.WithIdentity(jobKey));

        // Create a trigger for the job
        q.AddTrigger(opts => opts
            .ForJob(jobKey) // link to the HelloWorldJob
            .WithIdentity(typeof(T).FullName+"-trigger") // give the trigger a unique name
            .WithCronSchedule(cronFormat)
        ); 

        return q;
    }
}