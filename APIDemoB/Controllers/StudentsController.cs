using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDemoB.Models;

namespace APIDemoB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public List<Student> GetStudent()
        {
            return _context.Student.ToList();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return _context.Student.Find(id);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void PutStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    throw new KeyNotFoundException("Student not found");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Students
        [HttpPost]
        public void PostStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _context.Student.Remove(student);
            _context.SaveChanges();
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
