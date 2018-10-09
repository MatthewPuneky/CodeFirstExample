using System.Collections.Generic;
using System.Linq;
using ClassroomExample.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassroomExample.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly ClassroomExampleContext _context;

        public TeachersController(ClassroomExampleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TeacherGetDto> Get()
        {
            return _context.Teachers
                .Select(x => new TeacherGetDto
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName
                })
                .ToList();
        }

        [HttpGet("{teacherId}")]
        public TeacherGetDto Get(int teacherId)
        {
            return _context.Teachers
                .Select(x => new TeacherGetDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).First(x => x.Id == teacherId);
        }

        [HttpPost]
        public int Post([FromBody]TeacherPostDto teacherDto)
        {
            var teacherToCreate = new Teacher
            {
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName
            };

            var createdTeacher = _context.Teachers.Add(teacherToCreate);

            _context.SaveChanges();

            return createdTeacher.Entity.Id;
        }

        [HttpPut("{teacherId}")]
        public void Put(int teacherId, [FromBody]TeacherPutDto teacherDto)
        {
            var teacherToEdit = _context.Teachers.Find(teacherId);

            teacherToEdit.FirstName = teacherDto.FirstName;
            teacherToEdit.LastName = teacherDto.LastName;

            _context.SaveChanges();
        }

        [HttpDelete("{teacherId}")]
        public void Delete(int teacherId)
        {
            var teacherToRemove = _context.Teachers.Find(teacherId);
            _context.Teachers.Remove(teacherToRemove);
        }
    }
}
