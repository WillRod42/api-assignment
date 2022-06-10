using Microsoft.AspNetCore.Authentication.JwtBearer;  
using Microsoft.AspNetCore.Builder;  
using Microsoft.AspNetCore.Hosting;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Hosting;  
using Microsoft.IdentityModel.Tokens;  
using System.Text;  
using Shelter.Models;

namespace Shelter
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

      services.AddDbContext<ShelterContext>(options =>
      {
        options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"]));
        options.EnableSensitiveDataLogging();
      });
			
			services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ShelterContext>()
        .AddDefaultTokenProviders();

			services.AddAuthentication(options =>  
			{  
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
			})
			
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = false,
					ValidIssuer = Configuration["JWT:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
				};
			});

      services.AddControllers();
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseRouting();
      app.UseAuthorization();
			app.UseAuthentication(); 

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
