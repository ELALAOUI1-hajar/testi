using Microsoft.AspNetCore.Identity;

namespace testi.DBContext
{
    public class Admin : IdentityUser
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
