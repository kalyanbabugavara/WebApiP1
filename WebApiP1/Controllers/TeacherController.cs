using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiP1.Data;
using WebApiP1.Models.Domain;
using WebApiP1.Models.DTO;

namespace WebApiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        //hardcoded
        /*public IActionResult GetAll()
        {
            var Teachers = new List<Teacher>
            {
                new Teacher
                {
                    TeacherId=Guid.NewGuid(),
                    TeacherName="Sunil"
                },
                new Teacher
                {
                    TeacherId=Guid.NewGuid(),
                    TeacherName="Mahesh"
                }
            };
        return Ok(Teachers);
        }*/

        //from db

        private readonly ClgDetailsDbContext dbContext;
        public TeacherController(ClgDetailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* Asynchronous programmimg allows the prgm to continue executing other tasks while waiting
         * for long running operation to complete.
         * the main thread will not be blocked.
         */


        [HttpGet]//Get
        public async Task<IActionResult> GetAllData()
        {
            //Get data from DB - Domain models
            var teachers = await dbContext.Teachers.ToListAsync();

            //MapDomain models to DTO
            var TeachersDto = new List<TeacherDto>();
            foreach (var teacher in teachers)
            {
                TeachersDto.Add(new TeacherDto
                {
                    TeacherId = teacher.TeacherId,
                    TeacherName = teacher.TeacherName,
                    BranchCode = teacher.BranchCode,
                    Exp=teacher.Exp

                });

            }

            //Return DTO
            return Ok(TeachersDto);
        }


        [HttpGet] //Get(id)
        [Route("{id=Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var TeacherDomain = await dbContext.Teachers.SingleOrDefaultAsync(x => x.TeacherId == id);

            if (TeacherDomain == null)
            {
                return NotFound();
            }

            var teacherDto = new TeacherDto
            {
                TeacherId = TeacherDomain.TeacherId,
                TeacherName = TeacherDomain.TeacherName,
                BranchCode = TeacherDomain.BranchCode,
                Exp=TeacherDomain.Exp

            };

            return Ok(teacherDto);
        }



        [HttpPost] //post
        public async Task<IActionResult> Create([FromBody] AddTeacherRequestDto addTeacherRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map or convert DTO to Domain model
                var teacherDomainModel = new Teacher
                {
                    TeacherName = addTeacherRequestDto.TeacherName,
                    BranchCode = addTeacherRequestDto.BranchCode,
                    Exp = addTeacherRequestDto.Exp
                };
                //using domain model to create teacher in db
               await dbContext.Teachers.AddAsync(teacherDomainModel);
                await dbContext.SaveChangesAsync();

                //Map domain model back to dto
                var teacherDto = new TeacherDto
                {
                    TeacherId = teacherDomainModel.TeacherId,
                    TeacherName = teacherDomainModel.TeacherName,
                    BranchCode = teacherDomainModel.BranchCode,
                    Exp=teacherDomainModel.Exp

                };
                return CreatedAtAction(nameof(GetById), new { id = teacherDto.TeacherId }, teacherDto);

            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }



        [HttpPut] 
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTeacherRequestDto updateTeacherRequestDto)
        {
            if (ModelState.IsValid)
            {
                var TeacherDomain = await dbContext.Teachers.SingleOrDefaultAsync(x => x.TeacherId == id);

                if (TeacherDomain == null)
                {
                    return NotFound();
                }

                //map dto to domain model

                TeacherDomain.TeacherName = updateTeacherRequestDto.TeacherName;
                TeacherDomain.BranchCode = updateTeacherRequestDto.BranchCode;
                TeacherDomain.Exp = updateTeacherRequestDto.Exp;

                await dbContext.SaveChangesAsync();

                //Convert domain model to dto 

                var teacherDto = new TeacherDto
                {
                    TeacherId = TeacherDomain.TeacherId,
                    TeacherName = TeacherDomain.TeacherName,
                    BranchCode = TeacherDomain.BranchCode,
                    Exp = TeacherDomain.Exp

                };

                return Ok(teacherDto);
            }
            else
            {
                return BadRequest(ModelState);
            }

                
        }




        [HttpDelete] //Delete
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var TeacherDomain = await dbContext.Teachers.SingleOrDefaultAsync(x => x.TeacherId == id);

            if (TeacherDomain == null)
            {
                return NotFound();
            }

            dbContext.Teachers.Remove(TeacherDomain);
            await dbContext.SaveChangesAsync();

            return Ok();



        }
    }
}
