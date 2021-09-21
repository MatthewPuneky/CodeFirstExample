using System.Collections.Generic;

namespace Cmps285EntityFrameworkExample.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual List<StudentClass> StudentClasses { get; set; }
            = new List<StudentClass>();
    }

    public class ClassPostDto
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public int? TeacherId { get; set; }
    }

    public class ClassPutDto
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public int? TeacherId { get; set; }
    }

    public class ClassGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public int? TeacherId { get; set; }
    }
}