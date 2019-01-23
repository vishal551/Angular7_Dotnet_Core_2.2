using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly EmployeeDetailContext _context;
        public EmployeeDetailController(EmployeeDetailContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetail()
        {
            return await _context.employeeDetails.ToListAsync();
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> AddEmployeeDetail(EmployeeDetail  employeeDetail)

        {
            try
            {
                _context.employeeDetails.Add(employeeDetail);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmployeeDetail", new { id = employeeDetail.id }, employeeDetail);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if(id !=employeeDetail.id){
                return BadRequest();
            }
            _context.Entry(employeeDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetail>> DeleteEmployeeDetail(int id)
        {
            var employeeDetail = await _context.employeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            _context.employeeDetails.Remove(employeeDetail);
            await _context.SaveChangesAsync();
            return employeeDetail;
        }
    }
}
