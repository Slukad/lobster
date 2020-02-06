using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure.Models.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Web.Controllers
{
    [Route("api/Decision")]
    [ApiController]
    public class DecisionController : ControllerBase
    {
        private readonly IDataRepository<Models.Custom.Decision> _dataRepository;

        public DecisionController(IDataRepository<Models.Custom.Decision> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Decision
        [HttpGet]
        public IQueryable<Models.Custom.Decision> Get()
        {
            return _dataRepository.GetAll();
        }

        // GET: api/Decision/5
        [HttpGet("{id}")]
        public Models.Custom.Decision Get(int id)
        {
            return _dataRepository.Get(id);
        }

        // POST: api/Decision
        [HttpPost]
        public void Post([FromBody] Models.Custom.Decision value)
        {
            _dataRepository.Add(value);
        }

        // PUT: api/Decision/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Custom.Decision value)
        {
            _dataRepository.Update(value);
        }

        // DELETE: api/Decision/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataRepository.Delete(new Models.Custom.Decision() { Id = id });
        }
    }
}
