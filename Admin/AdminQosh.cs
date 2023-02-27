using Microsoft.Win32;
using Sharprompt;
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
    public class AdminQosh
    {
        public static User user = new User();
        IUserRepostry repostry = new UserRepostry();

        public bool AdminAdd() 
        {
            Console.Write("Ism: ");
            string name = Console.ReadLine();
            Console.Write("Familiya: ");
            string fam = Console.ReadLine();
            var password = Prompt.Password("Parol:");
            if (name != null & fam != null & password != null)
            {
                user.Name = name;
                user.Surname = fam;
                user.Fan = Registr.user.Fan;
                user.Password = password;
                user.Toifa = 1;
                repostry.Add(user);
                return true;
            }
            else
            {
                Console.WriteLine("Ma'lumotlar kam");
                return false;
            }
        }
    }
}
