using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassLecturesController : ControllerBase
    {
        private readonly smsdbcontext _context;

        public ClassLecturesController(smsdbcontext context)
        {
            _context = context;
        }

        // GET: api/ClassLectures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassLecture>>> GetClassLectures()
        {
            return await _context.ClassLectures.ToListAsync();
        }

        // GET: api/ClassLectures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassLecture>> GetClassLecture(int id)
        {
            var classLecture = await _context.ClassLectures.FindAsync(id);

            if (classLecture == null)
            {
                return NotFound();
            }

            return classLecture;
        }

        // PUT: api/ClassLectures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassLecture(int id, ClassLecture classLecture)
        {
            if (id != classLecture.Id)
            {
                return BadRequest();
            }

            _context.Entry(classLecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassLectureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClassLectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassLecture>> PostClassLecture(ClassLecture classLecture)
        {
            _context.ClassLectures.Add(classLecture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassLecture", new { id = classLecture.Id }, classLecture);
        }

        // DELETE: api/ClassLectures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassLecture(int id)
        {
            var classLecture = await _context.ClassLectures.FindAsync(id);
            if (classLecture == null)
            {
                return NotFound();
            }

            _context.ClassLectures.Remove(classLecture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassLectureExists(int id)
        {
            return _context.ClassLectures.Any(e => e.Id == id);
        }
    }
}
