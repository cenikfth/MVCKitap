﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebUygulamaProje1.Models.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
