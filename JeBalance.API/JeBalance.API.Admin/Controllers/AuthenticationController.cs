using JeBalance.API.Admin.Authentication;
using JeBalance.API.Admin.Authentication.JeBalance.API.Admin.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;


namespace JeBalance.API.Admin.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AdminUser> _adminManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;


		public AuthenticationController(
            UserManager<AdminUser> adminManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _adminManager = adminManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _adminManager.FindByNameAsync(model.Username);
            if (user != null && await _adminManager.CheckPasswordAsync(user, model.Password))
            {
                var UserRole = await _adminManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new (ClaimTypes.Name, user.UserName),
                    new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in UserRole)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

		[HttpPost]
		[Route("token")]
		public  async Task<IActionResult> GenerateToken([FromBody] LoginModel request)
        {
            if(request.Password.Equals("12345azerty") && request.Username.Equals("admin"))
            {
				AdminUser adminUser = new()
				{
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = request.Username
				};

				var authClaims = new List<Claim>
				{
					new (ClaimTypes.Name, adminUser.UserName),
					new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new (ClaimTypes.Role, UserRole.Admin),
				};

				var token = GetToken(authClaims);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo
				});

			}
            return Unauthorized(); 

		}

		[HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _adminManager.FindByNameAsync(model.NomUtilisateur);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AdminUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.NomUtilisateur
            };
            var result = await _adminManager.CreateAsync(user, model.MotDePasse);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));

            if (await _roleManager.RoleExistsAsync(UserRole.Admin))
            {
                await _adminManager.AddToRoleAsync(user, UserRole.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
