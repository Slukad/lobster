using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure.Models.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Web.Controllers
{
    [Route("api/Adventure")]
    [ApiController]
    public class AdventureController : ControllerBase
    {
        private readonly IDataRepository<Models.Custom.Adventure> _dataRepository;

        public AdventureController(IDataRepository<Models.Custom.Adventure> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Adventure
        [HttpGet]
        public IQueryable<Models.Custom.Adventure> Get()
        {
            return _dataRepository.GetAll().Take(10);
        }

        // GET: api/Adventure/5
        [HttpGet("{id}")]
        public Models.Custom.Adventure Get(int id)
        {
            return _dataRepository.Get(id);
        }

        // POST: api/Adventure
        [HttpPost]
        public void Post([FromBody] Models.Custom.Adventure value)
        {
            _dataRepository.Add(value);
        }

        // PUT: api/Adventure/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Custom.Adventure value)
        {
            _dataRepository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataRepository.Delete(new Models.Custom.Adventure() { Id = id });
        }
    }
}
