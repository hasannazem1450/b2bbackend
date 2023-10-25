using Microsoft.AspNetCore.Identity;

namespace B2B.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public string? Fullname { get; set; }
}