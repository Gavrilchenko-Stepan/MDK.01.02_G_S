using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class College
    {
        Dictionary<string, List<string>> groups_ = new Dictionary<string, List<string>>();

        public void AddGroup(string name, List<string> Students)
        {
            groups_.Add(name, Students);
        }

        public List<string> GetStudentGroup(string group) 
        {
            if (groups_.ContainsKey(group))
            {
                return null;
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
