using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSharprompt.Domain;

namespace TestSharprompt.Data
{
    public interface ITestRepostry
    {
        public bool Add(Test list);
        public List<Test> GetAll(Func<Test, bool> predicat = null);
        public bool Delete(Test test);
    }
}
