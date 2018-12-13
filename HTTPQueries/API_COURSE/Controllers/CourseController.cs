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
    public class CourseController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
            return Repository.Instance.GetAllCourses();
        }


        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            return Repository.Instance.GetCourse(id);
        }


        [HttpPost]
        public void Post([FromBody] Course value)
        {
            Repository.Instance.CreateCourse(value);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course value)
        {
            Repository.Instance.UpdateCourse(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.Instance.DeleteCourse(id);
        }
    }
}
