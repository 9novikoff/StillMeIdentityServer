using Microsoft.AspNetCore.Identity;

namespace StillMeIdentityServer
{
    public class User : IdentityUser
    {
        public byte[]? UserPicture { get; set; }
    }
}
