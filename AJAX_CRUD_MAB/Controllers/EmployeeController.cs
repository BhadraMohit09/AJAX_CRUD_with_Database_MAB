using AJAX_CRUD_MAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJAX_CRUD_MAB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.Select(e => new
            {
                e.Id,
                e.Name,
                e.Position,
                e.Age,
                e.Department
            }).ToListAsync();

            return Json(employees);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Json(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                // Log the errors (you can also inspect these in debug mode)
                foreach (var error in errors)
                {
                    Console.WriteLine(error); // Log to console or use your logger
                }
                return BadRequest(new { message = "Invalid data", errors });
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Json(employee);
        }



        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return Json(employee);
            }
            return BadRequest("Invalid data.");
        }

        [HttpDelete]
        [Route("Employee/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Json(employee);
            }
            return NotFound("Employee not found.");
        }
    }
}
