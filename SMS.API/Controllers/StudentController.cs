using Microsoft.AspNetCore.Mvc;
using SMS.API.Data;
using SMS.API.DomainModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public StudentController(ApplicationDbContext db)
        {
			this._db = db;
		}
        // GET: api/<StudentController>
        [HttpGet]
		public ActionResult Get()
		{
			var studentList = _db.Students.ToList();
			return Ok(studentList);
		}

		// GET api/<StudentController>/5
		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			var student = _db.Students.Find(id);
			if(student == null)
			{
				return BadRequest("Id is invalid");
			}
			return Ok(student);
		}

		// POST api/<StudentController>
		[HttpPost]
		public ActionResult Post([FromBody] Student entity)
		{
			_db.Students.Add(entity);
			_db.SaveChanges();
			return Ok(entity);
		}

		// PUT api/<StudentController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Student entity)
		{
			var existingStudent = _db.Students.Find(id);
			if(existingStudent == null)
			{
				return BadRequest("Invalid id");
			}
			existingStudent.RollNo=entity.RollNo;
			existingStudent.Address=entity.Address;
			existingStudent.Name = entity.Name;
			existingStudent.Email = entity.Email;
			_db.Students.Update(existingStudent);
			_db.SaveChanges();
			return Ok(existingStudent);
		}

		// DELETE api/<StudentController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var existingStudent=_db.Students.Find(id);
			if(existingStudent == null)
			{
				return BadRequest("invalid id");
			}
			_db.Students.Remove(existingStudent);
			_db.SaveChanges();
			return Ok("Student have benn deleted");
		}
	}
}
