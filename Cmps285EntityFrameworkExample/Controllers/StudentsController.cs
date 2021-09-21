using System.Collections.Generic;
using System.Linq;
using Cmps285EntityFrameworkExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cmps285EntityFrameworkExample.Controllers
{
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<StudentGetDto>> Get()
        {
            var studentToReturn = _context.Students
                .Select(x => new StudentGetDto
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName
                })
                .ToList();

            return Ok(studentToReturn);
        }

        [HttpGet("{studentId}")]
        public ActionResult<StudentGetDto> Get(int studentId)
        {
            var studentsToReturn = _context.Students
                .Select(x => new StudentGetDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).First(x => x.Id == studentId);

            return Ok(studentsToReturn);
        }

        [HttpPost]
        public ActionResult<StudentGetDto> Post([FromBody] StudentPostDto studentDto)
        {
            var studentToCreate = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName
            };

            _context.Students.Add(studentToCreate);

            _context.SaveChanges();

            var studentToReturn =  new StudentGetDto
            {
                Id = studentToCreate.Id,
                FirstName = studentToCreate.FirstName,
                LastName = studentToCreate.LastName,
            };

            return Ok(studentToReturn);
        }

        [HttpPut("{studentId}")]
        public ActionResult<StudentGetDto> Put(int studentId, [FromBody] StudentPutDto studentDto)
        {
            var studentToEdit = _context.Students.Find(studentId);

            studentToEdit.FirstName = studentDto.FirstName;
            studentToEdit.LastName = studentDto.LastName;

            _context.SaveChanges();

            var studentToReturn = new StudentGetDto
            {
                Id = studentToEdit.Id,
                FirstName = studentToEdit.FirstName,
                LastName = studentToEdit.LastName
            };

            return Ok(studentToReturn);
        }

        [HttpDelete("{studentId}")]
        public ActionResult Delete(int studentId)
        {
            var studentToRemove = _context.Students.Find(studentId);
            _context.Students.Remove(studentToRemove);

            return Ok();
        }

        [HttpGet("{studentId}/classes")]
        public ActionResult<IEnumerable<ClassGetDto>> GetStudentsClasses(int studentId)
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

            return Ok(classesUserIsIn);
        }

        [HttpPost("{studentId}/classes/{classId}")]
        public ActionResult RegisterStudentToClass(int studentId, int classId)
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

            return Ok();
        }

        [HttpDelete("{studentId}/classes/{classId}")]
        public ActionResult UnregisterStudentFromClass(int studentId, int classId)
        {
            var registration = _context.StudentsClasses
                .Single(x => x.StudentId == studentId
                          && x.ClassId == classId);

            _context.StudentsClasses.Remove(registration);
            _context.SaveChanges();

            return Ok();
        }
    }
}
