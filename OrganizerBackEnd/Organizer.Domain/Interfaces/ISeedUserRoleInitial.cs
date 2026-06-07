namespace Organizer.Domain.Interfaces;

public interface ISeedUserRoleInitial
{
    void SeedUsers(string email, string password, string role);
    void SeedRoles(string roleName);
}