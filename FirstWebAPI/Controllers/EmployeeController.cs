using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Data; // Import your Data folder where ApplicationDbContext is
using FirstWebAPI.Models; // ✅ Correct

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.tbl_E.ToList(); // Fetch data from database
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (emp == null)
            
                return BadRequest("Invalid employee data");

                _context.tbl_E.Add(emp);
                _context.SaveChanges();

                return Ok(new { message = "Employee Added Successfully" });

        }
    }
}
