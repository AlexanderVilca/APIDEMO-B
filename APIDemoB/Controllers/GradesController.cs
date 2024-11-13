using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDemoB.Models;

namespace APIDemoB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public GradesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public List<Grade> GetGrades()
        {
            return _context.Grades.ToList();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public Grade GetGrade(int id)
        {
            return _context.Grades.Find(id);
        }

        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public void PutGrade(int id, Grade grade)
        {
            if (id != grade.GradeID)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
                {
                    throw new KeyNotFoundException("Grade not found");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Grades
        [HttpPost]
        public void PostGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public void DeleteGrade(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade == null)
            {
                throw new KeyNotFoundException("Grade not found");
            }

            _context.Grades.Remove(grade);
            _context.SaveChanges();
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeID == id);
        }
    }
}
