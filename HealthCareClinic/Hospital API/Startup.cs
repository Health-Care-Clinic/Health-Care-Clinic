using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Hospital.Mapper;
using Microsoft.EntityFrameworkCore;
using Hospital.Schedule.Service;
using Hospital.Schedule.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Shared_model.Service;
using Hospital.Shared_model.Repository;
using Hospital.Medical_records.Service;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Repository;
using Hospital.Shared_model.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hospital.Tendering.Service;
using Hospital.Tendering.Repository;
using Hospital.Medicines.Service;
using Hospital.Medicines.Repository;
using Hospital.Events.Service;
using Hospital.Events.Repository;

namespace Hospital_API
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
            services.AddDbContext<HospitalDbContext>(options =>
                options.UseNpgsql(
                        ConfigurationExtensions.GetConnectionString(Configuration, "HospitalDbConnectionString"))
                    .UseLazyLoadingProxies());


            string key = "Nisam to sto mislis, samo jedna plavusa";

            services.AddAuthentication(x =>         
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddDbContext<EventsDbContext>(options =>
              options.UseNpgsql(
                      ConfigurationExtensions.GetConnectionString(Configuration, "EventsDbConnectionString"))
                  .UseLazyLoadingProxies());

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));     //za slanje mejlova
            services.AddTransient<IPatientService, PatientService>();

            services.AddScoped<IFeedbackMessageService, FeedbackMessageService>();
            services.AddScoped<IFeedbackMessageRepository, FeedbackMessageRepository>();

            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();

            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IFloorRepository, FloorRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            services.AddScoped<IAllergenService, AllergenService>();
            services.AddScoped<IAllergenRepository, AllergenRepository>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IProfilePictureRepository, ProfilePictureRepository>();

            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            
            services.AddScoped<IRenovationService, RenovationService>();
            services.AddScoped<IRenovationRepository, RenovationRepository>();

            services.AddScoped<IOnCallShiftService, OnCallShiftService>();
            services.AddScoped<IOnCallShiftRepository, OnCallShiftRepository>();

            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IVacationRepository, VacationRepository>();

            services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<ITenderRepository, TenderRepository>();

            services.AddScoped<ITenderResponseService, TenderResponseService>();
            services.AddScoped<ITenderResponseRepository, TenderResponseRepository>();

            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();

            services.AddScoped<IWorkDayShiftService, WorkDayShiftService>();
            services.AddScoped<IWorkDayShiftRepository, WorkDayShiftRepository>();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
