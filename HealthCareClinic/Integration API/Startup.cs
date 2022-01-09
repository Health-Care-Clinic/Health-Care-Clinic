using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using Integration.ApiKeys.Repository;
using Integration.ApiKeys.Service;
using Integration.Notifications.Repository;
using Integration.Notifications.Service;
using Integration.Pharmacy.Repository;
using Integration.Pharmacy.Service;
using Integration.Promotions.Repository;
using Integration.Promotions.Service;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace Integration_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddDbContext<IntegrationDbContext>(options =>
                options.UseNpgsql(
                    ConfigurationExtensions.GetConnectionString(Configuration, "IntegrationDbConnectionString")).UseLazyLoadingProxies());

            services.AddCors();
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackReplyRepository, FeedbackReplyRepository>();
            services.AddScoped<IFeedbackReplyService, FeedbackReplyService>();
            services.AddScoped<IPharmacyPromotionRepository, PharmacyPromotionRepository>();
            services.AddScoped<IPharmacyPromotionService, PharmacyPromotionService>();
            services.AddScoped<IMedConsumptionRepository, MedConsumptionRepository>();
            services.AddScoped<IMedConsumptionService, MedConsumptionService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
/*
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/Images")
            });*/
        }
    }
}
