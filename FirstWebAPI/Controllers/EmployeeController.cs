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
            var employees = _context.Employees.ToList(); // Fetch data from database
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeRequest emp)
        {
            try
            {

                if (emp == null || emp.EmployeeColl == null || !emp.EmployeeColl.Any())
                {
                    return NotFound("Invalid employee data");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                foreach (var employee in emp.EmployeeColl)
                {
                    employee.CreateBy = 1;
                    _context.Employees.Add(employee);
                }

                _context.SaveChanges();


                return Ok(new { message = "Employee Added Successfully", total = emp.EmployeeColl.Count });

            }
            catch (Exception ee)
            {
                return StatusCode(500, new { message = "error occured while adding", error = ee.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmpoyee(int id, [FromBody] Employee updatedEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingemp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (existingemp == null)
                {
                    return NotFound(new { message = $"the id {id} couldn't be found" });
                }

                existingemp.FirstName = updatedEmployee.FirstName;
                existingemp.Gender = updatedEmployee.Gender;
                existingemp.Religion = updatedEmployee.Religion;
                existingemp.PersnalContactNo = updatedEmployee.PersnalContactNo;
                existingemp.EmailId = updatedEmployee.EmailId;
                existingemp.CreateBy = 1; // Updating CreateBy manually for now

                _context.SaveChanges();

                return Ok(new { message = "updated successfully", id = existingemp.EmployeeId });
            }
            catch (Exception ee)
            {
                return StatusCode(500, new { message = "error while updating", error = ee.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var beData = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (beData == null)
                {
                    return NotFound(new { message = $"the id {id} couldn't be found" });
                }

                _context.Employees.Remove(beData);
                _context.SaveChanges();

                return Ok(new { message = "deleted successfully", Employeeid = id });
            }
            catch (Exception EE)
            {
                return StatusCode(500, new { message = " error while deleting", error = EE.Message });
            }


        }


    }
}
