using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ParkingSystemCoreBLL;
using System.Text;

namespace ParkingSystemCore
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
			services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

			// configure strongly typed settings objects
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			// configure jwt authentication
			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			// configure DI for application services
			if (GlobalVariable.logicType == 1)
			{
				services.AddScoped<IApprovalRepository, SqlApprovalManager>();
				services.AddScoped<IApprovalTypesRepository, SqlApprovalTypeManager>();
				services.AddScoped<ICellphoneRepository, SqlCellphoneManager>();
				services.AddScoped<ICourseRepository, SqlCourseManager>();
				services.AddScoped<IFacultyRepository, SqlFacultyManager>();
				services.AddScoped<IPersonRepository, SqlPersonManager>();
				services.AddScoped<IStudentRepository, SqlStudentManager>();
				services.AddScoped<ITeacherRepository, SqlTeacherManager>();
				services.AddScoped<ITelephoneRepository, SqlTelephoneManager>();
				services.AddScoped<IThreeObjectsRepository, SqlThreeObjectsManager>();
				services.AddScoped<IVehicleRepository, SqlVehicleManager>();
			}
			else if (GlobalVariable.logicType == 2)
			{
				services.AddScoped<IApprovalRepository, MySqlApprovalManager>();
				services.AddScoped<IApprovalTypesRepository, MySqlApprovalTypeManager>();
				services.AddScoped<ICellphoneRepository, MySqlCellphoneManager>();
				services.AddScoped<ICourseRepository, MySqlCourseManager>();
				services.AddScoped<IFacultyRepository, MySqlFacultyManager>();
				services.AddScoped<IPersonRepository, MySqlPersonManager>();
				services.AddScoped<IStudentRepository, MySqlStudentManager>();
				services.AddScoped<ITeacherRepository, MySqlTeacherManager>();
				services.AddScoped<ITelephoneRepository, MySqlTelephoneManager>();
				services.AddScoped<IThreeObjectsRepository, MySqlThreeObjectsManager>();
				services.AddScoped<IVehicleRepository, MySqlVehicleManager>();
			}
			else if (GlobalVariable.logicType == 3)
			{
				services.AddScoped<IApprovalRepository, InnerApprovalManager>();
				services.AddScoped<IApprovalTypesRepository, InnerApprovalTypeManager>();
				services.AddScoped<ICellphoneRepository, InnerCellphoneManager>();
				services.AddScoped<ICourseRepository, InnerCourseManager>();
				services.AddScoped<IFacultyRepository, InnerFacultyManager>();
				services.AddScoped<IPersonRepository, InnerPersonManager>();
				services.AddScoped<IStudentRepository, InnerStudentManager>();
				services.AddScoped<ITeacherRepository, InnerTeacherManager>();
				services.AddScoped<ITelephoneRepository, InnerTelephoneManager>();
				services.AddScoped<IThreeObjectsRepository, InnerThreeObjectsManager>();
				services.AddScoped<IVehicleRepository, InnerVehicleManager>();
			}
			else
			{
				services.AddScoped<IApprovalRepository, MongoApprovalManager>();
				services.AddScoped<IApprovalTypesRepository, MongoApprovalTypeManager>();
				services.AddScoped<ICellphoneRepository, MongoCellphoneManager>();
				services.AddScoped<ICourseRepository, MongoCourseManager>();
				services.AddScoped<IFacultyRepository, MongoFacultyManager>();
				services.AddScoped<IPersonRepository, MongoPersonManager>();
				services.AddScoped<IStudentRepository, MongoStudentManager>();
				services.AddScoped<ITeacherRepository, MongoTeacherManager>();
				services.AddScoped<ITelephoneRepository, MongoTelephoneManager>();
				services.AddScoped<IThreeObjectsRepository, MongoThreeObjectsManager>();
				services.AddScoped<IVehicleRepository, MongoVehicleManager>();
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
		{
			// global cors policy
			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseAuthentication();

			//app.UseMvc();
		}
	}
}
