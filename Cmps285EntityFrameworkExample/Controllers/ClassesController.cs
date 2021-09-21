using System.Collections.Generic;
using System.Linq;
using Cmps285EntityFrameworkExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cmps285EntityFrameworkExample.Controllers
{
    [Route("api/classes")]
    public class ClassesController : Controller
    {
        private readonly DataContext _context;

        public ClassesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClassGetDto>> Get()
        {
            var classesToReturn = _context.Classes
                .Select(x => new ClassGetDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Section = x.Section,
                    TeacherId = x.TeacherId
                })
                .ToList();

            return Ok(classesToReturn);
        }

        [HttpGet("{classId}")]
        public ActionResult<ClassGetDto> Get(int classId)
        {
            var classToReturn = _context.Classes
                .Select(x => new ClassGetDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Section = x.Section,
                    TeacherId = x.TeacherId
                }).First(x => x.Id == classId);

            return Ok(classToReturn);
        }

        [HttpPost]
        public ActionResult<ClassGetDto> Post([FromBody] ClassPostDto classDto)
        {
            var classToCreate = new Class
            {
                Name = classDto.Name,
                Section = classDto.Section,
                TeacherId = classDto.TeacherId
            };

            _context.Classes.Add(classToCreate);

            _context.SaveChanges();

            var classToReturn = new ClassGetDto
            {
                Id = classToCreate.Id,
                Name = classToCreate.Name,
                TeacherId = classToCreate.TeacherId,
                Section = classToCreate.Section,
            };

            return Ok(classToReturn);
        }

        [HttpPut("{classId}")]
        public ActionResult<ClassGetDto> Put(int classId, [FromBody] ClassPutDto classDto)
        {
            var classToEdit = _context.Classes.Find(classId);

            classToEdit.Name = classDto.Name;
            classToEdit.Section = classDto.Section;
            classToEdit.TeacherId = classDto.TeacherId;

            _context.SaveChanges();

            var classToReturn = new ClassGetDto
            {
                Id = classToEdit.Id,
                Name = classToEdit.Name,
                TeacherId = classToEdit.TeacherId,
                Section = classToEdit.Section,
            };

            return Ok(classToReturn);
        }

        [HttpDelete("{classId}")]
        public ActionResult Delete(int classId)
        {
            var classToRemove = _context.Classes.Find(classId);
            _context.Classes.Remove(classToRemove);

            Ok();
        }
    }
}
