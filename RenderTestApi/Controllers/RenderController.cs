using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenderTestApi.Entity;
using RenderTestApi.Model;

namespace RenderTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RenderController> _logger;
        private readonly IMapper _mapper;

        public static class InMemoryStudentStore
        {
            public static List<StudentEntity> Students = new List<StudentEntity>();
        }

        public RenderController(IConfiguration configuration, ILogger<RenderController> logger , IMapper mapper  )
        {
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("get-render-students")]

        public IActionResult GetStudents()
        {
            return Ok(InMemoryStudentStore.Students);
        }


        [HttpGet("get-render-student/{id}")]

        public IActionResult GetStudent(string id)
        {
            var result = InMemoryStudentStore.Students.Where(y => y.Id == id).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost("add-render-students")]
        public IActionResult AddRenderStudent(RegisterStudentModel model)
        {

            var mappedModel = _mapper.Map<StudentEntity>(model);

            InMemoryStudentStore.Students.Add(mappedModel);

            return Ok("Successfully added student");
        }

        [HttpDelete("delete-student/{id}")]

        public IActionResult DeleteStudent(string id)
        {
            var result = InMemoryStudentStore.Students.Where(x => x.Id == id).FirstOrDefault();
            InMemoryStudentStore.Students.Remove(result);
            return Ok("Deleted item");
        }

        [HttpPut("update-student/{id}")]
        public IActionResult UpdateStudent( [FromQuery]string id ,[FromBody] RegisterStudentModel updateRequest)
        {
            var result = InMemoryStudentStore.Students.Where(x => x.Id == id).FirstOrDefault();

            result.Email = updateRequest.Email;
            result.Age = updateRequest.Age;
            result.LastName = updateRequest.LastName;
            result.FirstName = updateRequest.FirstName;
     
            return Ok(result);
        }
    }
}
