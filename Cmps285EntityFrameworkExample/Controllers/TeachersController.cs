using System.Collections.Generic;
using System.Linq;
using Cmps285EntityFrameworkExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cmps285EntityFrameworkExample.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : Controller
    {
        private readonly DataContext _context;

        public TeachersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherGetDto>> Get()
        {
            var teachersToReturn = _context.Teachers
                .Select(x => new TeacherGetDto
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName
                })
                .ToList();

            return Ok(teachersToReturn);
        }

        [HttpGet("{teacherId}")]
        public ActionResult<TeacherGetDto> Get(int teacherId)
        {
            var teacherToReturn = _context.Teachers
                .Select(x => new TeacherGetDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).First(x => x.Id == teacherId);

            return Ok(teacherToReturn);
        }

        [HttpPost]
        public ActionResult<TeacherGetDto> Post([FromBody] TeacherPostDto teacherDto)
        {
            var teacherToCreate = new Teacher
            {
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                OfficeLocation = teacherDto.OfficeLocation,
            };

            _context.Teachers.Add(teacherToCreate);

            _context.SaveChanges();

            var teacherToReturn = new TeacherGetDto
            {
                Id = teacherToCreate.Id,
                FirstName = teacherToCreate.FirstName,
                LastName = teacherToCreate.LastName,
                OfficeLocation = teacherToCreate.OfficeLocation,
            };

            return Ok(teacherToReturn);
        }

        [HttpPut("{teacherId}")]
        public ActionResult<TeacherGetDto> Put(int teacherId, [FromBody] TeacherPutDto teacherDto)
        {
            var teacherToEdit = _context.Teachers.Find(teacherId);

            teacherToEdit.FirstName = teacherDto.FirstName;
            teacherToEdit.LastName = teacherDto.LastName;
            teacherToEdit.OfficeLocation = teacherDto.OfficeLocation;

            _context.SaveChanges();

            var teacherToReturn = new TeacherGetDto
            {
                Id = teacherToEdit.Id,
                FirstName = teacherToEdit.FirstName,
                LastName = teacherToEdit.LastName,
                OfficeLocation = teacherToEdit.OfficeLocation
            };

            return Ok(teacherToReturn);
        }

        [HttpDelete("{teacherId}")]
        public ActionResult Delete(int teacherId)
        {
            var teacherToRemove = _context.Teachers.Find(teacherId);
            _context.Teachers.Remove(teacherToRemove);

            return Ok();
        }
    }
}
