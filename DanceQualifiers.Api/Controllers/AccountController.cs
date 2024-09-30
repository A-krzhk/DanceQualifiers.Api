using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.Models;
using DanceQualifiers.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        AppUser user = new()
        {
            TelegramName = model.TelegramName,
            Name = model.Name,
            Surname = model.Surname,
            PhoneNumber = model.PhoneNumber,
            UserName = model.PhoneNumber
        };


        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, isPersistent: false);

            var token = _tokenService.GenerateJwtToken(user);

            return Ok(new
            {
                token = token,
                userName = user.UserName,
                email = user.Email
            });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return BadRequest(ModelState);
    }

    
}