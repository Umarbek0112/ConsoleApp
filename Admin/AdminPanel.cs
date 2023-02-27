using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Tests;

namespace TestSharprompt.Admin
{
    public class AdminPanel
    {
        public void AdminPanell() 
        {
            TestNatija natija = new TestNatija();
            RunTest test = new RunTest();
            AdminQosh AddAdmin = new AdminQosh();
            TestQosh AddTest = new TestQosh();

            var works = Prompt.Select("Kerakli tugmani tanlashingiz mumkin",
                new[] {"Natijalarni ko'rish", "Test yechish", "Admin qo'shish", "Test qo'shish" });

            if (works == "Natijalarni ko'rish")
                natija.TestNatijalar();
            else if (works == "Test yechish")
                test.RunTests();
            else if (works == "Admin qo'shish")
                AddAdmin.AdminAdd();
            else if(works == "Test qo'shish")
                AddTest.AddTest();
        }
    }
}
