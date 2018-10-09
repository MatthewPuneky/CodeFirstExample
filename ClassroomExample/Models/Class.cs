using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassroomExample.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Section { get; set; }
        
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<StudentClass> StudentClasses { get; set; }
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
