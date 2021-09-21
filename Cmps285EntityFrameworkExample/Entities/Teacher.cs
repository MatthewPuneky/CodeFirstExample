using System.Collections.Generic;

namespace Cmps285EntityFrameworkExample.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficeLocation { get; set; }

        public virtual List<Class> Classes { get; set; } = new List<Class>();
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