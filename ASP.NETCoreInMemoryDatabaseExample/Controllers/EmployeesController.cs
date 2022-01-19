using ASP.NETCoreInMemoryDatabaseExample.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NETCoreInMemoryDatabaseExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        [HttpPost]

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.SingleOrDefault(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (emp == null)
            {
                return NotFound($"Employee with the Id {id} does not exist");
            }
            else
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return Ok($"Employee with the Id {id} deleted successfully!");
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        { 
        _context.Employees.Add(employee);
            _context.SaveChanges();

            return Created("api/employees/"+employee.Id,employee);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (emp == null)
            {
                return NotFound($"Employee with the Id {id} does not exist");
            } 

            //employee null control vs.


            _context.Employees.Update(emp);
            _context.SaveChanges();

            return Ok($"Employee with the Id {id} updated successfully!");

        }


    }
}
