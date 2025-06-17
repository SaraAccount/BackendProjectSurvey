using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IRepository<Question> repository;
        public QuestionController(IRepository<Question> repository)
        {
            this.repository = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return repository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Question question)
        {
            repository.AddItem(question);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Question question)
        {
            repository.UpdateItem(question);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteItem(id);
        }
    }
}
