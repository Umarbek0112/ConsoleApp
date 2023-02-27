using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Domain;

namespace TestSharprompt.Data
{
    internal class TestRepostry : ITestRepostry
    {
        private string path = @"..\..\..\Baza\TestBaz.json"; 
        public bool Add(Test list)
        {
            var get = GetAll();
            if (get.LastOrDefault() == null)
                list.Id = 1;
            else
                list.Id = get.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            get.Add(list);
            string jsonGet = JsonConvert.SerializeObject(get, Formatting.Indented);
            File.WriteAllText(path, jsonGet);
            return true;
        }

        public bool Delete(Test test)
        {
            var users = GetAll();
            if (users.FirstOrDefault(x => x.Id == test.Id) == null) return false;
            users = users.Where(x => x.Id != test.Id).ToList();
            string jsonGet = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, jsonGet);
            return true;
        }

        public List<Test> GetAll(Func<Test, bool> predicat = null)
        {
            if (predicat == null)
            {
                string read = File.ReadAllText(path);
                var info = JsonConvert.DeserializeObject<List<Test>>(read);
                return info;
            }
            else
            {
                string read = File.ReadAllText(path);
                var info = JsonConvert.DeserializeObject<List<Test>>(read);
                return info.Where(predicat).ToList();
            }
            
        }
    }
}
