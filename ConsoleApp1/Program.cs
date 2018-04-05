using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            

            var id = WindowsIdentity.GetCurrent();
           // Debug.WriteLine(id.Name);

            var accout =new NTAccount(id.Name);
            var sid = accout.Translate(typeof(SecurityIdentifier));

          //  Debug.WriteLine(sid);

            foreach (var item in id.Groups.Translate(typeof(NTAccount)))
            {
             //   Debug.WriteLine(item.Value);
            }

            var principal = new WindowsPrincipal(id);
            var b = principal.IsInRole("BUILTIN\\Administrators");

            var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            //localAdmins stable SID
            var add = principal.IsInRole(localAdmins);
            Debug.WriteLine(add);

            var gi = new GenericIdentity("sd");
            DoWork();
        }

        [PrincipalPermission(SecurityAction.Demand,  Role = "BUILTIN\\Administrators")]
        public static void DoWork()
        {


        }
    }
}
