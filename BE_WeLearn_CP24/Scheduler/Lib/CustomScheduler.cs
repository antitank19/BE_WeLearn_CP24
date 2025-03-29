namespace API.Scheduler.Lib
{

    public interface ICustomQuarztHostedService : IHostedService
    {
        public Task ScheduleEmailReminder(DateTime sendTime, CancellationToken token);
    }
}
