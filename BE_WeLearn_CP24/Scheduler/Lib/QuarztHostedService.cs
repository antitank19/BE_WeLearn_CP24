using API.Scheduler.Jobs;
using API.Scheduler.Lib;
using APIExtension.Scheduler.Jobs;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Spi;
using static Quartz.Logging.OperationName;

namespace Utilities.ServiceExtensions.Scheduler.Lib;

//public class QuarztHostedService : IHostedService
public class QuarztHostedService : ICustomQuarztHostedService
{
    private readonly IJobFactory jobFactory;
    private IEnumerable<ScheduledJob> scheduledJobs;
    private readonly ISchedulerFactory schedulerFactory;

    private readonly Guid classGuid = Guid.NewGuid();


    public QuarztHostedService(IJobFactory jobFactory, IEnumerable<ScheduledJob> scheduledJobs,
        ISchedulerFactory schedulerFactory)
    {
        Console.WriteLine("Scheduler Service Started");
        var temp = new ScheduledJob(typeof(EmailReminderJob), CronScheduleExpression.FiveSecond);

        //this.scheduledJobs = scheduledJobs.Concat(new ScheduledJob[] { temp });
        this.scheduledJobs = scheduledJobs;
        this.jobFactory = jobFactory;
        this.schedulerFactory = schedulerFactory;
    }

    public IScheduler Scheduler { get; set; }

    public async Task StartAsync(CancellationToken token)
    {
        Scheduler = await schedulerFactory.GetScheduler(token);
        Scheduler.JobFactory = jobFactory;
        foreach (var scheduledJob in scheduledJobs)
        {
            IJobDetail job = CreateJob(scheduledJob);
            ITrigger trigger = CreateTrigger(scheduledJob);
            await Scheduler.ScheduleJob(job, trigger, token);
        }

        //IJobDetail reminderJobDetail = JobBuilder.Create(typeof(EmailReminderJob))
        ////IJobDetail reminderJobDetail = JobBuilder.Create(typeof(ThirtySecondJob))
        //    .WithIdentity("name", "group")
        //    .WithDescription(typeof(EmailReminderJob).Name)
        //    .SetJobData(new JobDataMap
        //    {
        //        ["SendTime"] = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.ff"),
        //        ["GroupId"] = 1,
        //        ["Guid"] = classGuid
        //    })
        //    .Build();
        //ITrigger reminderJobTrigger = TriggerBuilder.Create()
        //    //.WithIdentity($"{typeof(EmailReminderJob).FullName}")
        //    .ForJob("name", "group")
        //    .WithIdentity("name", "group")
        //    .WithDescription("Now")
        //    .StartAt(DateTime.Now.AddSeconds(2))
        //    .WithSimpleSchedule(x => x
        //       .WithIntervalInSeconds(5)
        //       .RepeatForever()
        //    )
        //    //.WithCronSchedule(ThirtySecondJob.schedule)
        //    .Build();
        //await Scheduler.ScheduleJob(reminderJobDetail, reminderJobTrigger, token);


        await Scheduler.Start(token);
    }

    public async Task StopAsync(CancellationToken token)
    {
        await Scheduler.Shutdown(token);
    }

    private static IJobDetail CreateJob(ScheduledJob scheduledJob)
    {
        Type type = scheduledJob.Type;
        Console.WriteLine($"Create {type.Name} Job");
        return JobBuilder.Create(type)
            .WithIdentity(type.FullName ?? string.Empty)
            .WithDescription(type.Name)
            .Build();
    }

    private static ITrigger CreateTrigger(ScheduledJob scheduledJob)
    {
        Type type = scheduledJob.Type;
        Console.WriteLine($"Create {type.Name} Trigger");
        return TriggerBuilder.Create()
            .WithIdentity($"{type.FullName}.trigger")
            .WithCronSchedule(scheduledJob.ScheduleExpression)
            .WithDescription(scheduledJob.ScheduleExpression)
            .Build();
    }



    public async Task ScheduleEmailReminder(DateTime sendTime, CancellationToken token)
    {
        if (Scheduler == null)
        {
            Scheduler = await schedulerFactory.GetScheduler(token);
        }
        Console.WriteLine($"Create Email Remider {sendTime} Trigger");
        Guid guid = new Guid();
        var reminderJobDetail = JobBuilder.Create<EmailReminderJob>()
            .SetJobData(new JobDataMap
            {
                ["SendTime"] = sendTime.ToString("dd/MM/yyyy hh:mm:ss.ff"),
                ["GroupId"] = 2,
                ["Guid"] = classGuid
            })
            .WithIdentity("EmailReminderJob-" + guid + "-" + sendTime.ToString("dd/MM/yyyy hh:mm:ss.ff"))
            .Build();
        var reminderJobTrigger  = TriggerBuilder.Create()
            .WithIdentity("EmailReminderJob - " + guid + " - " + sendTime.ToString("dd / MM / yyyy hh: mm:ss.ff"))
            //.ForJob("EmailReminderJob - " + guid + " - " + sendTime.ToString("dd / MM / yyyy hh: mm:ss.ff"))
            .ForJob(reminderJobDetail)
            .StartAt(sendTime)
            .Build();

        await Scheduler.ScheduleJob(reminderJobDetail, reminderJobTrigger, token);


        await Scheduler.Start(token);
    }
}