using EmployeeTask.Helpers;
using EmployeeTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeTask.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IAddressRepository addressRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetEmployees(int pg = 1)
        //{
        //    const int pageSize = 10;
        //    if (pg < 1)
        //        pg = 1;
        //    int recordsCount = _employeeRepository.GetCount();

        //    var pager = new Pagination(recordsCount, pg, pageSize);
        //    int skip = (pg - 1) * pageSize;

        //    var employers = await _employeeRepository.GetAllAsync(skip, pageSize);

        //    pager.EmployeeDtos = (IReadOnlyList<Dtos.EmployeeDto>)employers;

        //    return Ok(pager);

        //}

        [HttpPost]
        public async Task<IActionResult> GetEmployees()
        {
            var form = Request.Form;
            //var length = Request.Form["length"].FirstOrDefault();
            //var start = Request.Form["start"].FirstOrDefault();
            //int pageSize = int.Parse(length);
            //int skip = int.Parse(start);

            int recordsCount = _employeeRepository.GetCount();

            var employers = await _employeeRepository.GetAllAsync(/*skip, pageSize*/);

            var jsonData = new { recordsFiltered = recordsCount, recordsCount, data = employers };

            return Ok(jsonData);
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(HttpRequest request)
        //{
        //    var form = Request.Form;
        //    var length = Request.Form["length"].FirstOrDefault();
        //    var start = Request.Form["start"].FirstOrDefault();
        //    int pageSize = int.Parse(length);
        //    int skip = int.Parse(start);

        //    int recordsCount = _employeeRepository.GetCount();

        //    var employers = await _employeeRepository.GetAllAsync(skip, pageSize);

        //    var jsonData = new { recordsFiltered = recordsCount, recordsCount, data = employers };

        //    return Ok(jsonData);
        //}

    }
}
