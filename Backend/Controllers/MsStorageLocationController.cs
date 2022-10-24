using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MsStorageLocationController : Controller
    {
        private readonly TestContext _testContext;
        public MsStorageLocationController(TestContext context)
        {
            _testContext = context;
        }
        [HttpGet]
        public ActionResult<List<MsStorageLocation>> GetTrBpkbById(int id)
        {
            var trBpkb = _testContext.MsStorageLocations.Where(x => x.Id == id).ToList();
            return Ok(trBpkb);
        }
        [HttpPost]
        public async Task<ActionResult<List<MsStorageLocation>>> Add(MsStorageLocation req)
        {
            _testContext.Add(req);
            _testContext.SaveChanges();
            return Ok(req);
        }
        [HttpPut]
        public async Task<ActionResult<List<TrBpkb>>> Update(MsStorageLocation request)
        {
            var req = _testContext.MsStorageLocations.Where(x => x.Id == request.Id).FirstOrDefault();
            
            req.LocationId = request.LocationId;
            req.LocationName = request.LocationName;
            _testContext.Update(req);
            _testContext.SaveChanges();
            return Ok(req);
        }
    }
}
