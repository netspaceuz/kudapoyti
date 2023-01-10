using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Dtos.Common;
using kudapoyti.Service.Interfaces.CommentServices;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Graph;
using Microsoft.Graph.ExternalConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.CommentServices
{
    public class EmailService : IEmailService
    {
        private ICacheService _cacheService;
        public EmailService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task SendAsync(UserValidateDto user)
        {
            Random rd = new Random();
            int rand_num = rd.Next(100000, 999999);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("fresh.uzmarket@gmail.com", "vkvlahkgufjzzcqq"),
                    EnableSsl = true
                };

                mail.From = new MailAddress("fresh.uzmarket@gmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "Action Verification from kudapoyti.uz";
                mail.Body =
                    $"Hi," +
                    $"Please verify action\n" +
                    $"YOUR CODE IS - {rand_num}\n"
                    + "DON'T LET ANYONE TO KNOW THIS CODE OTHER THAN US\n";
                await smtp.SendMailAsync(mail);
                await _cacheService.SetValueAsync(rand_num.ToString(),user);
            }
            catch (Exception ex)
            {
                throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
