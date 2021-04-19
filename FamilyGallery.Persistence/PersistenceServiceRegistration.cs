using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Persistence.EntityFramework;
using FamilyGallery.Persistence.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FamilyGalleryDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("FamilyGalleryConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumMemberRepository, AlbumMemberRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
