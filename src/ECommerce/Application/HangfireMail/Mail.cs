using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using MailKit;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Application.HangfireMail
{
    public class Mail
    {
        private readonly IEmailTailRepository emailTailRepository;

        public Mail()
        {
        }

        public Mail(IEmailTailRepository emailTailRepository)
        {
            this.emailTailRepository = emailTailRepository;
        }

        public void SendEmail()
        {
            MailMessage msg = new MailMessage();
            var list = emailTailRepository.AsQueryable();
            list = list.Where(i => i.StatusSetting == Domain.Entities.EmailTail.Status.Unsuccessfull);
            foreach (var item in list)
            {
                msg.Subject = "";
                msg.From = new MailAddress("mhatipglu@gmail.com", "Muhammed Hatipoglu");
                msg.To.Add(new MailAddress(item.Email, "Bilgilendirme"));
                msg.IsBodyHtml = true;
                msg.Body = "";
                msg.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient("mhatipglu@gmail.com",587);
                NetworkCredential AccountInfo = new NetworkCredential("mhatipglu@gmail.com", "password");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = false;
                try
                {
                    smtp.Send(msg);
                    item.StatusSetting = Domain.Entities.EmailTail.Status.Successfull;
                    emailTailRepository.Update(item);
                }
                catch (Exception)
                {
                    item.TryCount += 1;
                    if(item.TryCount >= 5)
                    {
                        item.StatusSetting = Domain.Entities.EmailTail.Status.Unsuccessfull;
                        emailTailRepository.Update(item);
                    }
                    throw;
                }
            }
        }
        
    }
}