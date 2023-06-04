using EmployeeTask.Dtos;
using EmployeeTask.Models;

namespace EmployeeTask.Repositories
{
    public interface IAddressRepository
    {
        Task<int> AddAsync(Address model);
        Task<int> DeleteAsync(int id);
        Task<IList<AddressDto>> GetAddressesByWmployeeIdAsync(int employeeId);
        Task<IList<AddressDto>> GetAllAsync();
        Task<AddressDto> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, Address model);
    }
}