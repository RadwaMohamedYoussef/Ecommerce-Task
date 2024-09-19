using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }

    }
}