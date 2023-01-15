using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Dtos.Common;
using kudapoyti.Service.Interfaces.CommentServices;
using Microsoft.Extensions.Caching.Memory;
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
                mail.Subject = "Код подтверждения от KudaPoyti.Uz";
                mail.Body = "Пожалуйста, подтвердите свой адрес электронной почты." +
                    $"Проверочный код - {rand_num}";
                await smtp.SendMailAsync(mail);
                await _cacheService.SetValueAsync(user.Email,rand_num.ToString(),user);
            }
            catch (Exception ex)
            {
                throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
