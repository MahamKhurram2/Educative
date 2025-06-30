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
    public class TeachersController : ControllerBase
    {
        private readonly smsdbcontext _context; //this private read property is used to interact with db
      
        public TeachersController(smsdbcontext context)
        {
            _context = context; 
        }
        /* how it works:
       * first it checks whether we have coreesponding table or not
      if not found then it returns NotFound()
      else the other return statement will be execute
        whereby the db statement is converted into list and we get array of objects*/

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()

        {
            if (_context.Teachers == null)
            {
                return NotFound("Teachers table not found.");
            }

            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
         passinng id and updating the teacher object
            how it works:
        first we check if id of parameter with the id of within this instance here 
        if they match each other it will go with update opertion
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) //concurrency exception i.e  if multiple users try to update same record

            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*how it works
         firstly new teacher object is added to the db context
         then we save changes asynchronously- at backend enttity framework core will track changes to the entity and save them to the database
         finally we return CreatedAtAction which creates a new resource and returns the location of the newly created resource
         
         */
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);//except for last parameter, the rest are used to generate the URL for the newly created resource
        }

        // DELETE: api/Teachers/5
        /*
         how it works:
        firtsly it checks whether we have table or not
        then it will find the corresponding record with the given id using this method and delete it
        first it will delete it from db set then from table
         */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
