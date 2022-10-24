using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrBpkbController : Controller
    {
        private readonly TestContext _testContext;
        public TrBpkbController(TestContext context)
        {
            _testContext = context;
        }
        [HttpGet]
        public ActionResult<List<TrBpkb>> GetTrBpkbById(int id)
        {
            var trBpkb = _testContext.TrBpkbs.Where(x => x.Id == id).ToList();
            return Ok(trBpkb);
        }
        [HttpPost]
        public async Task<ActionResult<List<TrBpkb>>> Add(TrBpkb tr_Bpkb)
        {
            _testContext.Add(tr_Bpkb);
            _testContext.SaveChanges();
            return Ok(tr_Bpkb);
        }
        [HttpPut]
        public async Task<ActionResult<List<TrBpkb>>> Update(TrBpkb request)
        {
            var tr_Bpkb = _testContext.TrBpkbs.Where(x => x.Id == request.Id).SingleOrDefault();

            tr_Bpkb.BpkbNo = request.BpkbNo;
            tr_Bpkb.BpkbDate = request.BpkbDate;
            tr_Bpkb.BpkbDateIn = request.BpkbDateIn;
            tr_Bpkb.FakturNo = request.FakturNo;
            tr_Bpkb.BranchId = request.BranchId;
            tr_Bpkb.FakturDate = request.FakturDate;
            tr_Bpkb.LocationId = request.LocationId;
            tr_Bpkb.PoliceNo = request.PoliceNo;
            _testContext.Update(tr_Bpkb);
            _testContext.SaveChanges();
            return Ok(tr_Bpkb);
        }
    }
}
