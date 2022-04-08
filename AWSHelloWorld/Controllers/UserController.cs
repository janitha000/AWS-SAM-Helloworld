using Amazon.SQS;
using AWSHelloWorld.Core;
using AWSHelloWorldLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AWSHelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISQSHelper _sqsHelper;

        public UserController(ISQSHelper sqsHelper)
        {
            _sqsHelper=sqsHelper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
           var users = new List<User>()
           {
               new User("Janitha", "Tennakoon"),
               new User("Vindya", "Hettige"),

           };
            
            return users;
            
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            var response = await _sqsHelper.SendMessageAsync(id);
            return "sent";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
