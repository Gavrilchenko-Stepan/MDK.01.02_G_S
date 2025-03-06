using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class College
    {
        Student student = new Student("Пётр", 20);
        
        Dictionary<string, List<string>> groups_ = new Dictionary<string, List<string>>();

        void AddGroup(string group, List<string> students)
        {
            groups_.Add(group, students);
        }

        List<string> GetStudentGroup(string group) 
        { 
            return groups_[group];
        }
    }
}
