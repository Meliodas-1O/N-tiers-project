using JeBalance.API.InspectionFiscale.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JeBalance.API.InspectionFiscale.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<InspectionFiscaleUser> _inspecteurFiscaleManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthenticationController(
            UserManager<InspectionFiscaleUser> adminManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _inspecteurFiscaleManager = adminManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _inspecteurFiscaleManager.FindByNameAsync(model.Username);
            if (user != null && await _inspecteurFiscaleManager.CheckPasswordAsync(user, model.Password))
            {
                var UserRole = await _inspecteurFiscaleManager.GetRolesAsync(user);

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
        [Route("register-inspecteur-fiscale")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _inspecteurFiscaleManager.FindByNameAsync(model.NomUtilisateur);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            InspectionFiscaleUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.NomUtilisateur,
            };
            var result = await _inspecteurFiscaleManager.CreateAsync(user, model.MotDePasse);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"User creation failed {result.Errors}! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRole.Inspecteur))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Inspecteur));

            if (await _roleManager.RoleExistsAsync(UserRole.Inspecteur))
            {
                await _inspecteurFiscaleManager.AddToRoleAsync(user, UserRole.Inspecteur);
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
