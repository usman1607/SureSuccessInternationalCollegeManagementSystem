using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationPortal.Models
{
    public class StudentResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public StudentDto StudentDto { get; set; }
    }

    public class StudentsResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public IList<StudentDto> StudentDtos { get; set; }
    }
}
