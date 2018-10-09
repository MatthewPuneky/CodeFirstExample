using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassroomExample.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OfficeLocation { get; set; }

        public List<Class> Classes { get; set; }
    }

    public class TeacherPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficeLocation { get; set; }
    }

    public class TeacherPutDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficeLocation { get; set; }
    }

    public class TeacherGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficeLocation { get; set; }
    }
}
