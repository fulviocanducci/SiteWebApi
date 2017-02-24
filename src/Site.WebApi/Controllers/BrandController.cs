using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Site.Dal;
namespace Site.WebApi.Controllers
{
    [Route("api/[controller]")]    
    public class BrandController : Controller
    {
        private readonly IDalBrand Dal;
        public BrandController(IDalBrand dal)
        {
            Dal = dal;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return Dal.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            Brand brand = Dal.Find(id);
            return brand;
        }

        // POST api/values
        [HttpPost]
        public ObjectResult Post([FromBody]Brand value)
        {
            value = Dal.Insert(value);
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody]Brand value)
        {
            if (Dal.Edit(value))
            {
                return Ok(value);
            }
            return new NotFoundObjectResult(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            if (Dal.Delete(id))
            {
                return Ok(new { Status = "Success", Id = id });
            }
            return new NotFoundObjectResult(new { Status = "NotFound", Id = id });
        }
    }
}
