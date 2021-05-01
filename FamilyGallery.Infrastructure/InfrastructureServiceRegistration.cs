using FamilyGallery.Application.Contracts.Infrastructure;
using FamilyGallery.Application.Models.Mail;
using FamilyGallery.Infrastructure.Messaging.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings").Bind);
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IInviteService, InviteService>();
            return services;
        }
    }
}
