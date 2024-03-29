using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pharmacy;
using Pharmacy.UrgentMedicines;
using System;
using System.Threading;
using Pharmacy.ApiKeys.Repository;
using Pharmacy.ApiKeys.Service;
using Pharmacy.Feedbacks.Repository;
using Pharmacy.Feedbacks.Service;
using Pharmacy.FileCompression.Service;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Prescriptions.Repository;
using Pharmacy.Prescriptions.Service;
using UrgentMedicines.Protos;
using Pharmacy.Tendering.Repository;
using Pharmacy.Tendering.Service;
using Pharmacy.Advertisements.Repository;
using Pharmacy.Advertisements.Service;

namespace Pharmacy_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IMedicineService medicineService;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PharmacyDbContext>(options =>
               options.UseNpgsql(
                   ConfigurationExtensions.GetConnectionString(Configuration, "PharmacyDbConnectionString")).UseLazyLoadingProxies());

            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackReplyRepository, FeedbackReplyRepository>();
            services.AddScoped<IFeedbackReplyService, FeedbackReplyService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();

            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<ITenderResponseRepository, TenderResponseRepository>();
            services.AddScoped<ITenderResponseService, TenderResponseService>();
            ThreadPool.QueueUserWorkItem(FileCompressionService.CompressFiles);
        }

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
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

            IServiceScope scope1 = app.ApplicationServices.CreateScope();
            IServiceProvider sp1 = scope1.ServiceProvider;
            server = new Server
            {
                Services = { NetGrpcService.BindService(new UrgentMedicinesService(sp1.GetService<IMedicineService>())) },
                Ports = { new ServerPort("localhost", 8787, ServerCredentials.Insecure) }
            };
            server.Start();
            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }

        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }
    }
}
