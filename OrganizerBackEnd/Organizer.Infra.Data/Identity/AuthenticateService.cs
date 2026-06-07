using Microsoft.AspNetCore.Identity;
using Organizer.Domain.Interfaces;

namespace Organizer.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            email,
            password,
            false,
            false);
        return result.Succeeded;
    }

    public async Task<bool> RegisterAsync(string email, string password)
    {
        var applicationUser = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(applicationUser, password);
        if (result.Succeeded) await _signInManager.SignInAsync(applicationUser, false);
        return result.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}