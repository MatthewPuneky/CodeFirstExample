using System.Collections.Generic;
using System.Linq;
using ClassroomExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomExample.Controllers
{
    [Route("api/[controller]")]
    public class ClassesController : Controller
    {
        private readonly ClassroomExampleContext _context;

        public ClassesController(ClassroomExampleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ClassGetDto> Get()
        {
            return _context.Classes
                .Select(x => new ClassGetDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Section = x.Section,
                    TeacherId = x.TeacherId
                })
                .ToList();
        }
        
        [HttpGet("{classId}")]
        public ClassGetDto Get(int classId)
        {
            return _context.Classes
                .Select(x => new ClassGetDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Section = x.Section,
                    TeacherId = x.TeacherId
                }).First(x => x.Id == classId);
        }
        
        [HttpPost]
        public int Post([FromBody]ClassPostDto classDto)
        {
            var classToCreate = new Class
            {
                Name = classDto.Name,
                Section = classDto.Section,
                TeacherId = classDto.TeacherId
            };

            var createdClass = _context.Classes.Add(classToCreate);

            _context.SaveChanges();

            return createdClass.Entity.Id;
        }
        
        [HttpPut("{classId}")]
        public void Put(int classId, [FromBody]ClassPutDto classDto)
        {
            var classToEdit = _context.Classes.Find(classId);

            classToEdit.Name = classDto.Name;
            classToEdit.Section = classDto.Section;
            classToEdit.TeacherId = classDto.TeacherId;

            _context.SaveChanges();
        }

        [HttpDelete("{classId}")]
        public void Delete(int classId)
        {
            var classToRemove = _context.Classes.Find(classId);
            _context.Classes.Remove(classToRemove);
        }
    }
}
