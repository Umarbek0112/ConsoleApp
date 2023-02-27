using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Data;
using TestSharprompt.Domain;

namespace TestSharprompt.Autentifikatsa
{
    public class AutenTifikatsa
    {
        public bool AutenTifikatsya(User name) 
        {
            IUserRepostry user = new UserRepostry();
            var bsUser = user.GetAll()
                .Select(x => x)
                .FirstOrDefault(x => x.Password == name.Password & x.Name == name.Name);
            if (bsUser != null)
            {
                if (bsUser.Password == name.Password) return true;
                return false;
            }
            else
                return false;
        }
    }
}
