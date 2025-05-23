using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IRepository<Answer> repository;
        public AnswerController(IRepository<Answer> repository)
        {
            this.repository = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return repository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Answer Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Answer answer)
        {
            repository.AddItem(answer);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Answer answer)
        {
            repository.UpdateItem(answer);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteItem(id);
        }
    }
}
