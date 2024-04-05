using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace AudiophileEcommerceWebsite.Services;

public interface IUserService
{
    Task<IdentityUser> GetUser(ClaimsPrincipal user);
    
    Task<IdentityUser> GetCurrentUser();
}

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(UserManager<IdentityUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Task<IdentityUser> GetUser(ClaimsPrincipal user) => _userManager.GetUserAsync(user);

    public Task<IdentityUser> GetCurrentUser() => GetUser(_httpContextAccessor.HttpContext.User);
}