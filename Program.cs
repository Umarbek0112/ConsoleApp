using Sharprompt;
using System.Text;
using TestSharprompt.Admin;
using TestSharprompt.Autentifikatsa;
using TestSharprompt.Data;
using TestSharprompt.Domain;
using TestSharprompt.Tests;

namespace TestSharprompt
{
    public static class MyTest
    {
        public static void Main(String[] args) 
        {
            IUserRepostry metod = new UserRepostry();
            ITestRepostry metdTest = new TestRepostry();

            Console.OutputEncoding = Encoding.UTF8;
            Prompt.Symbols.Prompt = new Symbol("🐨", "?");
            Prompt.Symbols.Done = new Symbol("😎", "V");
            Prompt.Symbols.Error = new Symbol("😱", ">>");

            Registr reg = new Registr();
            RunTest testlar = new RunTest();
            AdminPanel admin = new AdminPanel();
            if (reg.Registratsiya())
            {
                if (Registr.user.Toifa == 1)
                    admin.AdminPanell();
                else
                    testlar.RunTests();
            }
            else
            {
                reg.Registratsiya();
            }
        }
    }
}