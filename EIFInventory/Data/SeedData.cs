using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EIFInventory.Data;

public class SeedData
{
    private const string AdminUserId = "01H6N7NV2P1KCVKY7F6EJH0FAF";
    private const string AdminRoleId = "01H6N7NV1KTPB9QDZ7FYDJ3HHK";
    private const string DeputyRoleId = "01H6N7NV1JHYY7N2NFDYX4ATAP";
    private const string LecturerRoleId = "01H6N7NV1YTMCV8YPZC7QQGGG7";
    private const string FacultyRoleId = "01H6N7NV18JWC8MYPXCVZR9WZW";
    private const string DepartmentRoleId = "01H6N7NV1MHQDXGNYH2HQT34V9";
    
    public static void Initialize(ModelBuilder modelBuilder)
    {
        SeedRoles(modelBuilder);
        SeedUsers(modelBuilder);
    }

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = DeputyRoleId, Name = "Deputy", NormalizedName = "DEPUTY" },
            new IdentityRole { Id = LecturerRoleId, Name = "Lecturer", NormalizedName = "LECTURER" },
            new IdentityRole { Id = FacultyRoleId, Name = "Faculty", NormalizedName = "FACULTY" },
            new IdentityRole { Id = DepartmentRoleId, Name = "Department", NormalizedName = "DEPARTMENT" }
        );
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<IdentityUser>();
        var adminUser = new IdentityUser
        {
            Id = AdminUserId,
            UserName = "admin@viko.lt",
            NormalizedUserName = "ADMIN@VIKO.LT",
            Email = "admin@viko.lt",
            NormalizedEmail = "ADMIN@VIKO.LT",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Kolegija1@"),
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        modelBuilder.Entity<IdentityUser>().HasData(adminUser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = AdminUserId,
            RoleId = AdminRoleId
        });
    }
    
}