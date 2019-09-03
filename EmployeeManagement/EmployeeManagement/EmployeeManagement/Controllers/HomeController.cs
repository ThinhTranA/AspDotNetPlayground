using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepositor;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepositor = employeeRepository;
        }
        public string Index ()
        {
            return _employeeRepositor.GetEmployee(1).Name;
        }
    }
}
