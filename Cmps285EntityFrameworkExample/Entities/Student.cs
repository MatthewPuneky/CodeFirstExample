using System.Collections.Generic;

namespace Cmps285EntityFrameworkExample.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<StudentClass> StudentClasses { get; set; }
            = new List<StudentClass>();
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
