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

            group.Students.Add(student);
            _groupRepository.UpdateGroup(group);

            return "Студент зачислен";
        }
    }
}
