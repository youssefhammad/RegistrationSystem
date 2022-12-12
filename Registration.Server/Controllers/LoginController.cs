using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Registration.Server.Core.IConfiguration;
using Registration.Shared.AuthModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Registration.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigurationSection _jwtSettings;


        public LoginController(UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login.IsAdmin == false)
            {
                var student = await _unitOfWork.Students.GetById(login.RegistrationId);
                if (student == null)
                {
                    return Unauthorized(new LoginResult { Error = "Invalid Authentication" });
                }
                else
                {
                    string aspId = student.UserId;

                    var user = await _userManager.FindByIdAsync(aspId);

                    if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        return Unauthorized(new LoginResult { Error = "Invalid Authentication" });
                    }
                    else
                    {
                        var signingCredentials = GetSigningCredentials();
                        var claims = await GetClaims(user);
                        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                        return Ok(new LoginResult { IsAuthSuccessful = true, Token = token });
                    }
                }
            }
            else
            {
                var admin = await _unitOfWork.Admins.GetById(login.RegistrationId);
                if (admin == null)
                {
                    return Unauthorized(new LoginResult { Error = "Invalid Authentication" });
                }
                else
                {
                    string aspId = admin.UserId;

                    var user = await _userManager.FindByIdAsync(aspId);

                    if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        return Unauthorized(new LoginResult { Error = "Invalid Authentication" });
                    }
                    else
                    {
                        var signingCredentials = GetSigningCredentials();
                        var claims = await GetClaims(user);
                        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                        return Ok(new LoginResult { IsAuthSuccessful = true, Token = token });
                    }
                }
            }
        }






        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }



        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id) //user.email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }



        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
