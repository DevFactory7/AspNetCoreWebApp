using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");

            //MailKit 이용

        }

        public async static Task SendEmailConfirmationAsync(string email, string link)
        {
            await MailKitSender(email, "디브팩토리 홈페이지 가입 이메일 인증",
                $"디브팩토리 홈페이지 가입을 완료하려면 <b><a href='{HtmlEncoder.Default.Encode(link)}'>여기</a></b>를 클릭해 이메일 인증을 완료 바랍니다.<br><br>감사합니다.");
        }

        /// <summary>
        /// 패스워드 분실시 이메일을 통한 비밀번호 재설정
        /// </summary>
        /// <param name="email"></param>
        /// <param name="link"></param>
        public async static Task SendEmailForgotPasswordAsync(string email, string link)
        {
            await MailKitSender(email, "디브팩토리 암호 재설정",
                $"디브팩토리 홈페이지 암호를 재설정 하시려면 <b><a href='{HtmlEncoder.Default.Encode(link)}'>여기</a></b>를 클릭해 이메일 인증을 완료 바랍니다.<br><br>감사합니다.");
        }


        public async static Task MailKitSender(string email, string subject, string message)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("디브팩토리", "devfactory7@naver.com"));
            msg.To.Add(new MailboxAddress(email));
            msg.Subject = subject;
            
            msg.Body = new TextPart("html")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.naver.com", 587, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("devfactory7", "dmsjj292513!");

                await client.SendAsync(msg);
                await client.DisconnectAsync(true);
            }
        }
    }
}
