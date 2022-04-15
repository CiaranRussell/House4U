using Microsoft.AspNetCore.Mvc;
using House4U.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=39786
namespace House4U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class House4UController : ControllerBase
    {
        static List<HouseEntries> housingStock = new List<HouseEntries>()
        { 
            new HouseEntries() {ID = "PR001", Address = "1 New Street", Email = "CR@gamil.com", leaseExpiry = new DateTime(2022, 1, 1), Lease = Lease.Delegated, NumBedrooms = 3 },
            new HouseEntries() {ID = "PR002", Address = "2 New Street", Email = "TR@gamil.com", leaseExpiry = new DateTime(2022, 5, 1), Lease = Lease.Managed, NumBedrooms = 4 },
            new HouseEntries() {ID = "PR003", Address = "3 New Street", Email = "PR@gamil.com", leaseExpiry = new DateTime(2022, 12, 1), Lease = Lease.Delegated, NumBedrooms = 2 },
        };


        // GET: api/<House4UController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(housingStock);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<House4UController>/5
        [HttpGet("ByID/{id}")]
        public IActionResult GetbyID(string _ID)
        {
            try
            {
                var stock = housingStock.Where(p => p.ID.Equals(_ID));
                if (stock != null)
                {
                    return Ok(stock);
                }
                else
                {
                    return BadRequest("ID not found");
                }

            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("/Email/{@}")]
        public IActionResult GetbyEmail(string _email)
        {
            var results = housingStock.FindAll(p => p.Email.ToLower().Contains(_email.ToLower()))
            .Select(HouseEntries => new {HouseEntries.Email });
            if (results.Count() == 0)
            {
                return NotFound();
            }
            return Ok(results);

        }

        // POST api/<House4UController>
        [HttpPost]
        public ActionResult PostAddProperty([FromBody] HouseEntries newProperty)
        {
            if (newProperty == null)
            {
                return BadRequest("No Data in Request");
            }
            HouseEntries h1 = housingStock.FirstOrDefault(p => p.ID.Equals(newProperty.ID));

            if (h1 != null)
            {
                return BadRequest("Record Aleady Exists");
            }
            housingStock.Add(newProperty);
            return Ok("Record Added");
        }

        // PUT api/<House4UController>/5
        [HttpPut("{id}")]
        public IActionResult PutUpdateBedrooms(string id, HouseEntries numbedroom)
        {
            try
            {
                HouseEntries he1 = housingStock.FirstOrDefault(p => p.ID.Equals(numbedroom.ID));

                if (he1 != null)
                {
                    he1.NumBedrooms = numbedroom.NumBedrooms;
                    return Ok("Record Updated");
                }
                return BadRequest("ID not found");
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }



        }


    }
}
