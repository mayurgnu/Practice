using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = new MockEmployeeRepository();
        }

        // Retrieve employee name and return
        //public string Index()
        //{
        //    return _employeeRepository.GetEmployee(1).Name;
        //}

        ////Controller returns JSON data
        ////In this case, Details() method always returns JSON data.
        ////It does not respect content negotiation and ignores the Accept Header.
        //public JsonResult Details1()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}

        ////The following example respects content negotiation.
        ////It looks at the Request Accept Header and if it is set to application/xml,
        ////then XML data is returned. If the Accept header is set to application/json, then JSON data is returned.
        //public ObjectResult Details2()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return new ObjectResult(model);
        //}
        public ViewResult Index()
        {
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }

        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}
