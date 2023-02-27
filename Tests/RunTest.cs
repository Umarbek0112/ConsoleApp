using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Autentifikatsa;
using TestSharprompt.Data;
using TestSharprompt.Domain;

namespace TestSharprompt.Tests
{
    public class RunTest
    {
        public void RunTests()
        {
            ITestRepostry metdTest = new TestRepostry();
            IUserRepostry metod = new UserRepostry();
            int temp = 0;
            int count = 0;
            var testSoni = Prompt.Select("Test turini tanlang", new[] { "3 talik testlar", "5 talik testlar", "10 talik testlar" });

            switch (testSoni)
            {
                case "3 talik testlar":
                    temp = 3;
                    break;
                case "5 talik testlar":
                    temp = 5;
                    break;
                case "10 talik testlar":
                    temp = 10;
                    break;
            }


            var te = metdTest.GetAll(x => x.UserFan == Registr.user.Fan).Select(v => v).ToList();
            int togr = 0;
            int natogr = 0;
            if (te.Count < temp)
            {
                Console.WriteLine(te.Count > 0 ? "Testlar soni kam kamroq test tanlab ko'ring \nYoki admindan test qo'shib berishini so'rang" : "Bazada test mavjud emas");
            }
            else
            {
                for (int i = 0; i < temp; i++)
                {
                    int son = ((int)te.Count / temp) * i;
                    var city = Prompt.Select(te[son].Savol, new[] { te[son].A, te[son].B, te[son].C });
                    if (city == te[son].Javob)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Sizning javobingiz \"{city}\" to'g'ri!");
                        togr++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sizning javobingiz \"{city}\" nato'g'ri!");
                        natogr++;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (temp == togr + natogr)
                {
                    Console.WriteLine("Bazaga qo'shildi");
                    Registr.user.Natija = Registr.user.Natija == null ? $"T:{togr}, N:{natogr}" : $"{Registr.user.Natija} | T:{togr}, N:{natogr}";
                    metod.Update(Registr.user);
                }
                Console.WriteLine("Natija: " + 100 / temp * togr + "%");
            }
        }
    }
}
