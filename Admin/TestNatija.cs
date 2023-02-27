using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Autentifikatsa;
using TestSharprompt.Data;
using TestSharprompt.Domain;

namespace TestSharprompt.Admin
{
    public class TestNatija
    {
        public void TestNatijalar() 
        {
            IUserRepostry users = new UserRepostry();
            var natija = users.GetAll(x => x.Fan == Registr.user.Fan);
            ConsoleTable
               .From<User>(natija)
               .Configure(o => o.NumberAlignment = Alignment.Left)
               .Write(Format.Alternative);
        }
    }
}
