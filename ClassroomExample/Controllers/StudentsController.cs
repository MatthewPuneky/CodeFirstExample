using System.Collections.Generic;
using System.Linq;
using ClassroomExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomExample.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly ClassroomExampleContext _context;

        public StudentsController(ClassroomExampleContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<StudentGetDto> Get()
        {
            return _context.Students
                .Select(x => new StudentGetDto
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName
                })
                .ToList();
        }
        
        [HttpGet("{studentId}")]
        public StudentGetDto Get(int studentId)
        {
            return _context.Students
                .Select(x => new StudentGetDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).First(x => x.Id == studentId);
        }
        
        [HttpPost]
        public int Post([FromBody]StudentPostDto studentDto)
        {
            var studentToCreate = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName
            };

            var createdStudent = _context.Students.Add(studentToCreate);

            _context.SaveChanges();

            return createdStudent.Entity.Id;
        }
        
        [HttpPut("{studentId}")]
        public void Put(int studentId, [FromBody]StudentPutDto studentDto)
        {
            var studentToEdit = _context.Students.Find(studentId);

            studentToEdit.FirstName = studentDto.FirstName;
            studentToEdit.LastName = studentDto.LastName;

            _context.SaveChanges();
        }
        
        [HttpDelete("{studentId}")]
        public void Delete(int studentId)
        {
            var studentToRemove = _context.Students.Find(studentId);
            _context.Students.Remove(studentToRemove);
        }

        [HttpGet("{studentId}/Classes")]
        public IEnumerable<ClassGetDto> GetStudentsClasses(int studentId)
        {
            var classesUserIsIn =
                (from classes in _context.Classes
                join studentClasses in _context.StudentsClasses
                    on classes.Id equals studentClasses.ClassId
                select new ClassGetDto
                {
                    Id = classes.Id,
                    Name = classes.Name,
                    Section = classes.Section,
                    TeacherId = classes.TeacherId
                })
                .ToList();

            return classesUserIsIn;
        }

        [HttpPost("{studentId}/Classes/{classId}")]
        public void RegisterStudentToClass(int studentId, int classId)
        {
            var student = _context.Students.Find(studentId);
            var @class = _context.Classes.Find(classId);

            var registration = new StudentClass
            {
                StudentId = student.Id,
                Student = student,
                ClassId = @class.Id,
                Class = @class
            };

            _context.StudentsClasses.Add(registration);
            _context.SaveChanges();
        }

        [HttpDelete("{studentId}/Classes/{classId}")]
        public void UnregisterStudentFromClass(int studentId, int classId)
        {
            var registration = _context.StudentsClasses
                .Single(x => x.StudentId == studentId
                          && x.ClassId == classId);

            _context.StudentsClasses.Remove(registration);
            _context.SaveChanges();
        }
    }
}
