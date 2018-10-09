using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassroomExample.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public List<StudentClass> StudentClasses { get; set; }
    }

    public class StudentPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentPutDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
