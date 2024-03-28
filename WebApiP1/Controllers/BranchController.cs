using Microsoft.AspNetCore.Mvc;
using WebApiP1.Data;
using WebApiP1.Models.DTO;



namespace WebApiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly ClgDetailsDbContext dbContext;
        public BranchController(ClgDetailsDbContext dbContext)  
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Get data from database - Domain models
            var Branches = dbContext.Branches.ToList();

            //Map domain models to DTO
            var branchsdto = new List<Models.DTO.BranchDto>();

            foreach (var branch in Branches)
            {
                branchsdto.Add(new BranchDto()
                {
                    BranchId=branch.BranchId,
                    BranchName=branch.BranchName,
                    BranchCode=branch.BranchCode

                });
            }
            
            //Return DTO...
            return Ok(Branches);
        }

        [HttpGet]
        [Route("{id=Guid}")]

        public IActionResult GetById([FromRoute] Guid id) 
        {
            //var Branch = dbContext.Branches.Find(id); only for primarykey
            var Branch = dbContext.Branches.SingleOrDefault(x=> x.BranchId== id);

            if(Branch == null)
            {
                return NotFound();
            }
            return Ok(Branch);
        }

        
    }
}
