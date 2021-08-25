using BTuPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTuPresupuesto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ExpenditureController(ApplicationDBContext Context)
        {
            _context = Context;
        }
        // GET: api/<ExpenditureController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listExpenditures = await _context.Expenditure.ToListAsync();
                return Ok(listExpenditures);
            } catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // POST api/<ExpenditureController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Expenditure expenditure)
        {
            try
            {
                _context.Add(expenditure);
                await _context.SaveChangesAsync();
                return Ok(expenditure);
            } catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // PUT api/<ExpenditureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Expenditure expenditure)
        {
            try
            {
                if(id != expenditure.Id)
                {
                    return NotFound();
                }

                _context.Update(expenditure);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Success" });
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // DELETE api/<ExpenditureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var expenditure = await _context.Expenditure.FindAsync(id);

                if(expenditure == null)
                {
                    return BadRequest();
                }

                _context.Expenditure.Remove(expenditure);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Se eliminó con éxito." });
            } catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
