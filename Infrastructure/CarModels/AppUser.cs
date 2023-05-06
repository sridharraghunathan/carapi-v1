using Microsoft.AspNetCore.Identity;

namespace Infrastructure.CarModels
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
 
 