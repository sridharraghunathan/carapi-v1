using System.Text;
using Infrastructure.CarModels;
using Infrastructure.IdentityContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    //Service generally static implementation since its should be application Life Time 
    //Also its independent on user.
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(
        this IServiceCollection serviceCollection,
        IConfiguration config){    
            var builder = serviceCollection.AddIdentityCore<AppUser>();
            builder =   new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDBContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            //Adding the code for Authentication check while receiving the token
            
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            return  serviceCollection;
        }
    }
}