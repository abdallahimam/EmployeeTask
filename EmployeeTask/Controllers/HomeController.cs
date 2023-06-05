using EmployeeTask.Dtos;
using EmployeeTask.Helpers;
using EmployeeTask.Models;
using EmployeeTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public HomeController(IEmployeeRepository employeeRepository, IAddressRepository addressRepository, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _logger = logger;
        }
        [Route("~/")]
        [Route("~/Home")]
        [Route("~/Home/Index")]
        [Route("~/Employee")]
        [Route("~/Employee/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pg = 1)
        {
            const int pageSize = 2;
            if (pg < 1)
                pg = 1;
            int recordsCount = _employeeRepository.GetCount();

            var pager = new Pagination(recordsCount, pg, pageSize);
            int skip = (pg - 1) * pageSize;

            var employers = await _employeeRepository.GetAllAsync(skip, pageSize);

            pager.EmployeeDtos = (IReadOnlyList<EmployeeDto>)employers;

            ViewBag.pager = pager;
            return View();
        }

        [HttpPost]
        [Route("~/Employee/Create")]
        public async Task<IActionResult> Create(EmployeeCreate model)
        {
            var addressesStr = Request.Form["addresses[]"].ToList();
            
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = new Employee { Name = model.Name, Age = model.Age };
                    employee.Id = await _employeeRepository.AddAsync(employee);
                    var addresses = addressesStr.Select(p => new Address { Description = p, EmployeeId = employee.Id }).ToList();
                    await _addressRepository.AddRangeAsync(addresses);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                }

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("~/Employee/Update/{id}")]
        public async Task<IActionResult> Update(int id, EmployeeEdit model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var employee = new Employee { Name = model.Name, Age = model.Age };
                    employee.Id = await _employeeRepository.UpdateAsync(id, employee);
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                }

            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [Route("~/Employee/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                    
                await _employeeRepository.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("~/Employee/UpdateAddress/{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressEdit model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var address = new Address { Id = id, Description = model.Description };
                    await _addressRepository.UpdateAsync(id, address);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                }

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("~/Employee/DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            try
            {
                var address = new Address { Id = id };
                await _addressRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction(nameof(Index));
        }

    }
}
