using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class College
    {
        private Dictionary<string, List<string>> groups_ = new Dictionary<string, List<string>>();

        public void AddGroup(string name, List<string> students)
        {
            groups_.Add(name, students);
        }

        public List<string> GetStudentGroup(string group)
        {
            if (groups_.TryGetValue(group, out List<string> students))
            {
                return students;
            }
            else
            {
                Console.WriteLine($"Группа '{group}' не найдена. Проверьте правильность написания названия группы.");
                return new List<string>();
            }
        }
    }
}
