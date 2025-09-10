using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxStudents { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
