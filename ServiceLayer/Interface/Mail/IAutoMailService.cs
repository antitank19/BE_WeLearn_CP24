using DataLayer.DbObject;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Implemention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface.Mail
{
    public interface IAutoMailService
    {
        public Task<bool> SendEmailWithDefaultTemplateAsync(IEnumerable<string> receivers, string subject, string content,
       IFormFileCollection attachments);

        public Task<bool> SendConfirmResetPasswordMailAsync(string username, string serverLink);
        public Task<bool> SendNewPasswordMailAsync(string username);
        public Task<bool> SendMonthlyStatAsync();

        //public Task<bool> SendPaymentReminderAsync();

    }
}
