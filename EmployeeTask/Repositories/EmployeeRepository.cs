using AutoMapper;
using EmployeeTask.Dtos;
using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<EmployeeDto>> GetAllAsync()
        {
            var employees = await _dbContext.Employees.Include(e => e.Addresses).ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<IList<EmployeeDto>> GetAllAsync(int skip, int pageSize)
        {
            var employees = await _dbContext.Employees.Include(e => e.Addresses).Skip(skip).Take(pageSize).ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public int GetCount()
        {
            return _dbContext.Employees.Count();
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            return _mapper.Map<EmployeeDto>(employee);

        }

        public async Task<int> AddAsync(Employee model)
        {
            try
            {
                await _dbContext.Employees.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return model.Id;
        }

        public async Task<int> UpdateAsync(int id, Employee model)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);
                if (employee == null)
                    return -1;

                employee.Name = model.Name;
                employee.Age = model.Age;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);
                if (employee != null)
                {
                    _dbContext.Addresss.RemoveRange(_dbContext.Addresss.Where(a => a.EmployeeId == id).ToList());
                    _dbContext.Employees.Remove(employee);
                }
                if (_dbContext.ChangeTracker.HasChanges())
                    await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }

    }
}
