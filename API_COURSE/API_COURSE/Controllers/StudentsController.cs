using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models;

namespace API_COURSE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Repository.Instance.GetAllStudents();
        }

        // GET api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            return Repository.Instance.GetStudentById(id);
        }

        // POST api/Students
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            Repository.Instance.CreateStudent(value);
        }

        // PUT api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            Repository.Instance.UpdateStudent(value);
        }

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.Instance.DeleteStudent(id);
        }
    }
}
