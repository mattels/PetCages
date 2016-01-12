using Storage;
using System.Web.Http;
using System.Web.Http.Cors;
using PetCagesService.Models;

namespace PetCagesService.Controllers
{
    [RoutePrefix("api")]    
    public class CageController : ApiController
    {                
        [Route("cages")]
        [HttpGet()]
        [EnableCors(origins: "http://http://localhost", headers: "*", methods: "*")]
        public IHttpActionResult GetCages()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.CageAnimals();

            if (warehouse.Cages == null)
            {
                return NotFound();
            }

            return Ok(warehouse.Cages);
        }
        /*
        [Route("animals")]
        [HttpGet()]
        public IHttpActionResult GetAnimals()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.CageAnimals();

            if (warehouse.Animals == null)
            {
                return NotFound();
            }
            
            return Ok(warehouse.Animals);
        }

        [Route("warehouse")]
        [HttpGet()]
        public IHttpActionResult GetWareHouse()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.CageAnimals();

            if (warehouse.Cages == null || warehouse.Animals == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }
        */ 
    }
}
