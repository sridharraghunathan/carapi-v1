using core.Dtos;
using API.error;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Infrastructure.CarModels;
using Infrastructure.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{    public class AccountController : BaseApiController
    {
        //Constructor where we inject the other class 
        //controller intialized the constructor will  be created
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
 
        public AccountController(
            UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
         ITokenService tokenService
        )
        {
            _signInManager = signInManager;
            _tokenService  = tokenService; 
            _userManager = userManager;
        }

        [HttpGet ]
        public async Task <ActionResult<UserDto>> GetCurrentUserAsync(){
        var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
       
        var  userStatus = await _userManager.FindByEmailAsync(email);
                 return new UserDto {
                    UserName = userStatus.UserName ,
                    Email = userStatus.Email,
                    Token = _tokenService.CreateToken(userStatus)
                };
        }

        [HttpGet("emailexists")]
        public async Task<bool> EmailIdExists([FromQuery] string email){

            return await _userManager.FindByEmailAsync(email) != null ;
        }
     
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginUser (LoginDto loginDto){
            //   1)  Check whether user is available  
            var userStatus = await    _userManager.FindByEmailAsync(loginDto.Email);
            if(userStatus == null) return Unauthorized(new ApiResponse(401));
            //   2) check whether password is correct
              var passwordStatus = await _signInManager.CheckPasswordSignInAsync(
                   userStatus,
                  loginDto.Password,false);
               if(!passwordStatus.Succeeded) return Unauthorized(new ApiResponse(401));
                return new UserDto {
                    UserName = userStatus.UserName ,
                    Email = userStatus.Email,
                    Token = _tokenService.CreateToken(userStatus)
                };
        }

     
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser( RegisterDto registerDto){

            // Check email Id already exist or not
            if(EmailIdExists(registerDto.Email).Result){
                return new BadRequestObjectResult(new  ApiValidationError {
                    Errors = new [] {"Email already in use"}
                });
            }

            //1) creating the user 
            var User = new AppUser {
                Email = registerDto.Email,
                UserName =registerDto.DisplayName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };           
                var userCreateStatus = await _userManager.CreateAsync(User, registerDto.Password );
            if(!userCreateStatus.Succeeded) return BadRequest(new ApiResponse(400));
                return new UserDto {
                    Email = registerDto.Email ,
                    Token = _tokenService.CreateToken(User),
                    UserName = registerDto.DisplayName,
                };
        }
    }  
}