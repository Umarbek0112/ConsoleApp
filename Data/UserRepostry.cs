using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Domain;
using Newtonsoft.Json;

namespace TestSharprompt.Data
{
    internal class UserRepostry : IUserRepostry
    {
        private string path = @"..\..\..\Baza\UserBaza.json";
        public bool Add(User user)
        {
            var get = GetAll();
            if (get.LastOrDefault() == null)
            {
                user.Id = 1;
                user.Toifa = 1;
            }
            else
                user.Id = get.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            get.Add(user);
            string jsonGet = JsonConvert.SerializeObject(get, Formatting.Indented);
            File.WriteAllText(path, jsonGet);
            return true;
        }


        public bool Delete(User user)
        {
            var users = GetAll();
            if (users.FirstOrDefault(x => x.Id == user.Id) == null) return false;
            users = users.Where(x => x.Id != user.Id).ToList();
            string jsonGet = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, jsonGet);
            return true;
        }

        public User Get(Func<User, bool> predecat)
            => GetAll(predecat).FirstOrDefault();


        public List<User> GetAll(Func<User, bool> predicate = null)
        {
            string read = File.ReadAllText(path);
            var info = JsonConvert.DeserializeObject<List<User>>(read);
            if (string.IsNullOrEmpty(read) | info.FirstOrDefault() == null)
            {
                return new List<User>();
            }

            if (predicate == null)
                return info;
            else
                return info.Where(predicate).ToList();
        }

        public bool Update(User user)
        {
            var users = GetAll();
            var getUser = users.FirstOrDefault(x => x.Id == user.Id);
            if (getUser != null)
            {
                getUser.Name = user.Name ?? getUser.Name;
                getUser.Surname = user.Surname ?? getUser.Surname;
                getUser.Password = user.Password ?? getUser.Password;
                getUser.Fan = user.Fan ?? getUser.Fan;
                getUser.Natija = user.Natija ?? getUser.Natija;
            }
            else
            {
                return false;
            }
            users.GroupBy(x => x.Id);
            string jsonGet = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, jsonGet);


            return true;
        }
    }
}
