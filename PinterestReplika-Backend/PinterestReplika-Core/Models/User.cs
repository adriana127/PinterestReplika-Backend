using Microsoft.AspNetCore.Identity;

namespace PinterestReplika_Core.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
