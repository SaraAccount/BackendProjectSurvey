using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        IRepository<Survey> repository;
        public SurveyController(IRepository<Survey> repository)
        {
            this.repository = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Survey> Get()
        {
            return repository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Survey Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Survey survey)
        {
            repository.AddItem(survey);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] Survey survey)
        {
            repository.UpdateItem(survey);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteItem(id);
        }
    }
}
