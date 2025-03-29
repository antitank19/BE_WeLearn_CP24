using Quartz;

namespace API.Scheduler.Jobs
{
    internal class EmailReminderJob : IJob
    {
        //DateTime SendDate;
        //public EmailReminderJob(DateTime sendDate)
        //{
        //    SendDate = sendDate;
        //}
        public EmailReminderJob()
        {
            
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Email Reminder Job: ");

            JobDataMap jobDataMap = context.JobDetail.JobDataMap;
            string sendTimeString = (string)jobDataMap["SendTime"];
            int groupId = (int)jobDataMap["GroupId"];
            Guid guid = (Guid)jobDataMap["Guid"];

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("SendTime: " + sendTimeString);
            Console.WriteLine("GroupId: " + groupId);
            Console.WriteLine("Guid: " + guid);

            //Console.WriteLine(SendDate.ToString("dd/MM/yyyy hh:mm:ss.ff")+ " send noti mail");
        }
    }
}
