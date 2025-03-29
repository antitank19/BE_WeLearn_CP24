using Quartz;
using ServiceLayer.Services.Interface;
using ServiceLayer.Services.Interface.Mail;
using Utilities.ServiceExtensions.Scheduler.Lib;

namespace APIExtension.Scheduler.Jobs
{
    //0 0 ** Wed    
    public class WeeklyJob: IJob
    {
        public static readonly string schedule = CronScheduleExpression.Weekly;
        private readonly IAutoMailService mailService;


        public WeeklyJob(IServiceProvider service)
        {
            var scope = service.CreateScope();
            //mailService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Mails;
            this.mailService = scope.ServiceProvider.GetRequiredService<IServiceWrapper>().Mails;
            //this.mailService = mailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Weekly Task started at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}");
            await mailService.SendEmailWithDefaultTemplateAsync(
                new[] { "trankhaiminhkhoi@gmail.com", "trankhaiminhkhoi10a3@gmail.com" },
                "Test Weekly Job Scheduler",
                $"Email sent at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}",
                null
            );
            await mailService.SendEmailWithDefaultTemplateAsync(new List<string>() { "trankhaiminhkhoi10a3@gmail.com" }, "Test weekly scheduler", "GS scheduler is working", null);
            await mailService.SendMonthlyStatAsync();
            Console.WriteLine($"Weekly Task completed at {DateTime.Now.ToString("dd/MM/yy hh.mm.ss")}");
            //return Task.CompletedTask;
        }
    }
}
