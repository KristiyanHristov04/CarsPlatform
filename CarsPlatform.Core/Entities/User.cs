using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
    }
}
