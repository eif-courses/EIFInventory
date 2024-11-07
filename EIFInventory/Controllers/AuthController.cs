using Microsoft.AspNetCore.Identity;

namespace EIFInventory.Controllers;

public class AuthController
{
    public static void MapAuthEndpoints(WebApplication app)
    {
        app.MapGet("/auth/access-denied", AccessDenied);
        app.MapPost("/auth/login", LogIn);
        app.MapGet("/auth/logout", LogOut).RequireAuthorization();
    }


    private static async Task<IResult> LogIn(
        HttpContext httpContext,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        string email,
        string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return Results.Json(new { error = "Invalid email or password." }, statusCode: 401);
        }

        var result =
            await signInManager.PasswordSignInAsync(user, password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return Results.Ok("Logged in successfully");
        }

        return Results.Json(new { error = "Invalid email or password." }, statusCode: 401);
    }

    private static async Task<IResult> LogOut(HttpContext httpContext, SignInManager<IdentityUser> signInManager)
    {
        if (httpContext.User.Identity?.IsAuthenticated == true)
        {
            await signInManager.SignOutAsync();
            return Results.Ok("Logged out successfully");
        }

        return Results.BadRequest("User is not logged in.");
    }

    private static IResult AccessDenied()
    {
        return Results.Problem("Access denied. You do not have permission to view this resource.", statusCode: 403);
    }
}