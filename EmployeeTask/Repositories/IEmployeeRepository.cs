using EmployeeTask.Dtos;
using EmployeeTask.Models;

namespace EmployeeTask.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> AddAsync(Employee model);
        Task<int> DeleteAsync(int id);
        Task<IList<EmployeeDto>> GetAllAsync();
        Task<IList<EmployeeDto>> GetAllAsync(int skip, int pageSize);
        Task<EmployeeDto> GetByIdAsync(int id);
        int GetCount();
        Task<int> UpdateAsync(int id, Employee model);
    }
}