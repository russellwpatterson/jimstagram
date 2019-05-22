using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Jimstagram.PostsApi.Helpers
{
    public static class JwtHelper
    {
        public static string GetUsername(IEnumerable<Claim> claims)
        {
            var loginUsername = string.Empty;

            var identityClaim = (from c in claims
                                 where c.Type == "identity"
                                 select c).FirstOrDefault();

            if (identityClaim != null)
            {
                loginUsername = identityClaim.Value;
            }

            return loginUsername;
        }
    }
}