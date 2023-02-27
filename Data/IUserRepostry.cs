using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Domain;

namespace TestSharprompt.Data
{
    internal interface IUserRepostry
    {
        public User Get(Func<User, bool> predecat);
        public bool Add(User user);
        public bool Update(User user);
        public bool Delete(User user);
        public List<User> GetAll(Func<User, bool> predicate = null);

    }
}
