using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class CollageService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;

        public CollageService(IStudentRepository studentRepository, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }

        public string EnrollStudent(int studentId, int groupId)
        {
            var student = _studentRepository.GetStudentID(studentId);
            var group = _groupRepository.GetGroup(groupId);

            if (student == null)
            {
                return "Студент не найден";
            }

            if (group == null)
            {
                return "Группа не найдена";
            }

            if (group.Students.Count >= group.MaxStudents)
            {
                return "Группа заполнена";
            }

            if (group.Students.Any(s => s.Id == student.Id))
            { 
                return "Студент уже в группе"; 
            }

            group.Students.Add(student);
            _groupRepository.UpdateGroup(group);

            return "Студент зачислен";
        }
    }
}
