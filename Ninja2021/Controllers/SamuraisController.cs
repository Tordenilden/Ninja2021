using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ninja2021.Models;

namespace Ninja2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        // en kommentar
        private readonly DatabaseContext _context;

        public SamuraisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Samurais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        {
            return await _context.Samurais.ToListAsync();
        }

        [HttpGet("name")] // min URL  -- api/samurais/name
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamuraiName()
        {
            return await _context.Samurais.Where(s => s.name == "Hando San").ToListAsync();
        }

        [HttpGet("battles/{numberOfBattles}")] //??  -- api/samurais/battles
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamuraiMoreThanNumberBattles(int numberOfBattles)
        {
            return await _context.Samurais.Where(samuraiObj => samuraiObj.battlesFought > numberOfBattles).ToListAsync();
            //return await _context.Samurais.Where(s => s.name == "Hando San").ToListAsync();
        }

        [HttpGet("battles8")] //??  -- api/samurais/battles
        public async Task<ActionResult<Samurai>> GetSamuraiMoreThanNumberBattles8(string samuraiName)
        {
            // Kom så Sigurd!!
            // routeparams eller er det parameter eller er det en af de 6? [FromBody]
            //var tt = _context.Samurais.Contains

            return await _context.Samurais.Where(samuraiObj => samuraiObj.name == samuraiName).SingleOrDefaultAsync();
            //return await _context.Samurais.Where(s => s.name == "Hando San").ToListAsync();
        }


        // api/samurais/battlesFought
        [HttpGet("battlesFought")]
        public async Task<ActionResult<Samurai>> GetSamuraiWithMaxBattles()
        {// vi vil gerne trække max nummer ud fra battlesFought

            var temp = await _context.Samurais.MaxAsync(sa => sa.battlesFought);
            return Ok(temp); // denne linje er vigtig!! typecast
        }

        // api/samurais/battlesFought2
        [HttpGet("battlesFought2")]
        public async Task<ActionResult<Samurai>> GetSamuraiWithMaxBattles2()
        {// vi vil gerne trække max nummer ud fra battlesFought

            var temp = await _context.Samurais.Select(s => s.battlesFought).MaxAsync();
            Samurai obj = new Samurai();
            obj.battlesFought = temp;
            obj.name = "Kenneth";
            obj.samuraiId = 99;
            return obj;
        }

        [HttpGet("join1m")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoin1()
        {


            // vi vil gerne have data ud fra samurai og mm tabellen
            var temp = await _context.Samurais.Include(s => s.samuraiBattles).ToListAsync();   // join eller Include eller querysyntax

            return Ok(temp);
        }

        [HttpGet("joinmm")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoin2()
        {// vi vil gerne trække max nummer ud fra battlesFought


            // vi vil gerne have data ud fra samurai, battle og samuraisInBattle
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle).ToListAsync(); // cartesian product hvilket er rigtig skidt!!
            // det tager vi lige imorgen
            // hvis I skal have orderby eller where på eller group er det efter dette join.
            //eksempelvis
            //.Where(base => base.battleProperty == noget)
// m-m
// array.include(s=>s.list).theninclude(?)
// table-table-table
// table1.include(table2).include(table3).include(table4)



            return Ok(temp);

        }

        [HttpGet("joinmmAnonymous")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoin55()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)
                .Select((x) => new
                {
                    hansiVariabel = x.battlesFought,
                    hansiVariabel2 = 55,
                }).ToListAsync();
            return Ok(temp);

        }
        [HttpGet("joinmmAnonymous1")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous1()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)
                .Select((x) => new
                {
                    x
                }).ToListAsync();
            return Ok(temp);

        }
        [HttpGet("joinmmAnonymous2")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous2()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)
                .Select(x=>x).ToListAsync();
            return Ok(temp);

        }
        //dårlig kode ikke fleksibelt
        [HttpGet("joinmmAnonymous3")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous3()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)
                .Select(x => x)
                .Where(blodig => blodig.name == "Gandalf the White")
                .ToListAsync();
            return Ok(temp);
        }

        [HttpGet("joinmmAnonymous4")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous4()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)
                
                .Where(blodig => blodig.name == "Gandalf the White")
                .Select(x => new
                {
                    x.name,
                    test = x.samuraiBattles.Select(nuKiggerDenAlleBattlesIgennem=>nuKiggerDenAlleBattlesIgennem.battle.name)
                })
                .ToListAsync();
            return Ok(temp);
        }

        [HttpGet("joinmmAnonymous5")]
        public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous5()
        {
            var temp = await _context.Samurais.Include(s => s.samuraiBattles)
                .ThenInclude(sb => sb.battle)

                .Where(blodig => blodig.name == "Gandalf the White")
                .Select(x => new
                {
                    x.name,
                    test = x.samuraiBattles[0].battle.name
                })
                .ToListAsync();
            return Ok(temp);
        }

        //[HttpGet("joinmmAnonymous6")]
        //public async Task<ActionResult<Samurai>> GetSamuraiJoinAnonymous6()
        //{
        //    var temp = await _context.Samurais.Include(s => s.samuraiBattles)
        //        .ThenInclude(sb => sb.battle)

        //        .Where(blodig => blodig.name == "Gandalf the White")
        //        .Select(x => new
        //        {
        //            x.name,
        //            //Foreach er muligvis dum, men kan give en Action
        //            test = x.samuraiBattles.ForEach(nuKiggerDenAlleBattlesIgennem => nuKiggerDenAlleBattlesIgennem.battle)
        //        })
        //        .ToListAsync();
        //    return Ok(temp);
        //}
        //[HttpGet("enandenroute")]
        //public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        //{
        //    return await _context.Samurais.ToListAsync();
        //}

        // GET: api/Samurais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        // PUT: api/Samurais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamurai(int id, Samurai samurai)
        {
            if (id != samurai.samuraiId)
            {
                return BadRequest();
            }

            _context.Entry(samurai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamuraiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Samurais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Samurai>> PostSamurai(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamurai", new { id = samurai.samuraiId }, samurai);
        }

        // DELETE: api/Samurais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Samurai>> DeleteSamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }

            _context.Samurais.Remove(samurai);
            await _context.SaveChangesAsync();

            return samurai;
        }

        private bool SamuraiExists(int id)
        {
            return _context.Samurais.Any(e => e.samuraiId == id);
        }
    }
}
