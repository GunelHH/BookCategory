using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HomeTaskBookCategory.DTOs.Account;
using HomeTaskBookCategory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HomeTaskBookCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountsController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            AppUser user = await userManager.FindByNameAsync(dto.Username);
            if (user != null) return BadRequest();

            user = new AppUser
            {
                Name = dto.Name,
                UserName = dto.Username,
                Email = dto.Email,
                Surname = dto.Surname
            };

            IdentityResult result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            IdentityResult rollResult = await userManager.AddToRoleAsync(user, "Member");
            if (!rollResult.Succeeded) return BadRequest(rollResult.Errors);
            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            AppUser user = await userManager.FindByNameAsync(dto.Username);
            if (user is null) return NotFound("Tapilmadiiii");

            var result = await userManager.CheckPasswordAsync(user, dto.Password);
            if (!result)
                return BadRequest(new
                {
                    code="Password or Username",
                    description="Password or Username is incorrect"
                });

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.UserData,user.UserName)
            };
            IList<string> roles = await userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim("Role", r)));

            string keyStr = "a9028251-341c-429b-971f-d379145a05da";

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5001/",
                audience: "https://localhost:5001/",
                signingCredentials:credentials,
                expires:DateTime.Now.AddDays(1),
                claims:claims
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenStr);
        }


        //[HttpGet("roll")]

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await roleManager.CreateAsync(new IdentityRole("Moderator"));
        //    await roleManager.CreateAsync(new IdentityRole("Member"));
        //    return Ok();
        //}
    }
}