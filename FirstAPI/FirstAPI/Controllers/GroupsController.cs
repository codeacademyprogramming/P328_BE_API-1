using FirstAPI.DAL;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public GroupsController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public ActionResult<List<Group>> GetAll()
        {
            var data = _context.Groups.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Group> Get(int id)
        {
            var data = _context.Groups.Find(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost("")]
        public ActionResult Create(Group group)
        {
            if(_context.Groups.Any(x=>x.No == group.No))
            {
                ModelState.AddModelError("No", "No is already exist");
                return BadRequest(ModelState);
            }

            _context.Groups.Add(group);
            _context.SaveChanges();

            return StatusCode(201, new {Id=group.Id});
        }

    }
}
