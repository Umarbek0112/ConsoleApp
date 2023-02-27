using Sharprompt;
using TestSharprompt.Autentifikatsa;
using TestSharprompt.Data;
using TestSharprompt.Domain;
using TestSharprompt.Tests;

namespace TestSharprompt.Admin
{
    public class TestQosh
    {
        public bool AddTest()
        {
            Console.WriteLine("Addtest");

            string path = @"..\..\..\..\";
            string[] asa = Directory.GetFileSystemEntries(path, "*.txt", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < asa.Length; i++)
            {
                asa[i] = asa[i].Split(@"\").Last();
            }
            var file = Prompt.Select("Testingiz mavjud faileni tanlashingiz mumkin", asa);

            string[] read = File.ReadAllText(path + file).Split("\n");
            Test temp = new Test();
            List<Test> list = new List<Test>();
            
            for (int i = 0; i < read.Length; i++)
            {
                int t = (i + 1) % 5;
                switch (t)
                {
                    case 1:
                        temp.Savol = read[i].Trim();
                        break;
                    case 2:
                        temp.A = read[i].Trim();
                        break;
                    case 3:
                        temp.B = read[i].Trim();
                        break;
                    case 4:
                        temp.C = read[i].Trim();
                        break;
                    case 0:
                        temp.Javob = read[i].Trim();
                        break;
                }
                temp.UserFan = Registr.user.Fan;
                if ((i + 1) % 5 == 0)
                {
                    list.Add(temp);
                    temp = new Test();
                }
            }

            ITestRepostry test = new TestRepostry();
            foreach (var item in list)
            {
                test.Add(item);
            }
            
            return true;
        }
    }
}
