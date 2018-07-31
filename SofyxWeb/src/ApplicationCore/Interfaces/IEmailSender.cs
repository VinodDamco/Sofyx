﻿using System.Threading.Tasks;

namespace SofyxWeb.ApplicationCore.Interfaces
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
