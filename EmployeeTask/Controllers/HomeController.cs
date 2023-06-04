using EmployeeTask.Helpers;
using EmployeeTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public async Task<IActionResult> Index(int pg = 1)
        //{
        //    const int pageSize = 2;
        //    if (pg < 1)
        //        pg = 1;
        //    int recordsCount = _employeeRepository.GetCount();

        //    var pager = new Pagination(recordsCount, pg, pageSize);
        //    int skip = (pg - 1) * pageSize;

        //    var employers = await _employeeRepository.GetAllAsync(skip, pageSize);

        //    pager.EmployeeDtos = (IReadOnlyList<Dtos.EmployeeDto>)employers;
        //    ViewBag.Pager = pager;

        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
