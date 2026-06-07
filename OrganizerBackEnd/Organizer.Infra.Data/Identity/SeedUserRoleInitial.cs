using Microsoft.AspNetCore.Identity;
using Organizer.Domain.Interfaces;

namespace Organizer.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles(string roleName)
    {
        if (!_roleManager.RoleExistsAsync(roleName).Result)
        {
            var role = new IdentityRole();
            role.Name = roleName;
            role.NormalizedName = roleName.ToUpperInvariant();
            _roleManager.CreateAsync(role);
        }
    }

    public void SeedUsers(string email, string password, string role = "User")
    {
        if (_userManager.FindByEmailAsync(email).Result == null)
        {
            var user = new ApplicationUser();
            user.Email = email;
            user.NormalizedEmail = email.ToUpperInvariant();
            user.UserName = email;
            user.NormalizedUserName = email.ToUpperInvariant();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(user, password).Result;
            if (result.Succeeded) _userManager.AddToRoleAsync(user, role).Wait();
        }
    }
}