using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  
using Microsoft.IdentityModel.Tokens;  
using System;  
using System.Collections.Generic;  
using System.IdentityModel.Tokens.Jwt;  
using System.Security.Claims;  
using System.Text;  
using System.Threading.Tasks; 
using Shelter.Models;


namespace Shelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticateController : ControllerBase
  {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			var userExists = await _userManager.FindByNameAsync(model.Email);
			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

			ApplicationUser user = new ApplicationUser()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Email
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

			return Ok();
		}
	}
}