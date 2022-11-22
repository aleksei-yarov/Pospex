using Microsoft.AspNetCore.Identity;

namespace Pospex.Models
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] Image { get; set; } = Array.Empty<byte>();
    }
}
