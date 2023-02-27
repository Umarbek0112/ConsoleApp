
using Sharprompt;
using System.Diagnostics.Metrics;
using TestSharprompt.Data;
using TestSharprompt.Domain;

namespace TestSharprompt.Autentifikatsa
{
    public class Registr
    {
        public static User user = new User();

        public bool Registratsiya()
        {
            var RegLog = Prompt.Select("Registr/Login", new[] { "Registr", "Login" });
            
            IUserRepostry repostry = new UserRepostry();
            if (RegLog == "Registr")
            {
                Console.Write("Ismingizni kiriting: ");
                string name = Console.ReadLine();
                Console.Write("Familiyangizni kiriting: ");
                string fam = Console.ReadLine();
                var til = Prompt.Select("Tilni tanlang: ", new[] { "C#", "Pyhton", "C++"});
                var password = Prompt.Password("Type new password");
                if (name != null & fam != null & til != null & password != null )
                {
                    user.Name = name;
                    user.Surname = fam;
                    user.Fan = til;
                    user.Password = password;                 
                    repostry.Add(user);
                    return true;
                }
                else
                {
                    Console.WriteLine("Ma'lumotlar kam");
                    return false;
                }

            }
            else if (RegLog == "Login")
            {
                Console.Write("Ismingizni kiriting: ");
                string name = Console.ReadLine();
                var password = Prompt.Password("Type new password");
                User usern = repostry.Get(
                    x => x.Password == password
                    & x.Name == name
                );
                user = usern;
                AutenTifikatsa asd = new AutenTifikatsa();
                if (user != null)
                {
                    if (asd.AutenTifikatsya(user))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
                
                
            }
            else
                return false;
        }
    }
}
