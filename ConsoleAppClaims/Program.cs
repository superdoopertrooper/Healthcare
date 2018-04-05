using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppClaims
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupClaimsPrincipal();
            var cp = ClaimsPrincipal.Current;
            Debug.WriteLine(cp.Identity.Name);
        }

        private static void NewMethod()
        {
            SetupClaimsPrincipal();

            var cp = Thread.CurrentPrincipal as ClaimsPrincipal;
            Debug.WriteLine(cp.Claims.Count());

            Debug.WriteLine(Thread.CurrentPrincipal.Identity.IsAuthenticated);
            Debug.WriteLine(cp.Identity.Name);
            Debug.WriteLine(cp.FindFirst(ClaimTypes.Role).Value);
        }

        private static void SetupClaimsPrincipal()
        {
            var claims = SetupClaims();

            var id = new ClaimsIdentity(claims, "Custom", ClaimTypes.Email, ClaimTypes.Role);

            var p = new ClaimsPrincipal(id);
            Thread.CurrentPrincipal = p;
        }

        private static ICollection<Claim> SetupClaims( )
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, "remzy@Email.com"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "remzy@NameIdentifier.com"));
            claims.Add(new Claim(ClaimTypes.Name, "remzy@Name.com"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            return claims;
        }
    }
}
