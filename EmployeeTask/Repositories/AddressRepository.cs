using AutoMapper;
using EmployeeTask.Dtos;
using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<AddressDto>> GetAllAsync()
        {
            var addresses = await _dbContext.Addresss.ToListAsync();

            return (IList<AddressDto>)_mapper.Map<AddressDto>(addresses);
        }


        public async Task<IList<AddressDto>> GetAddressesByWmployeeIdAsync(int employeeId)
        {
            var addresses = await _dbContext.Addresss.Where(a => a.EmployeeId == employeeId).ToListAsync();

            return (IList<AddressDto>)_mapper.Map<AddressDto>(addresses);
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await _dbContext.Addresss.FindAsync(id);
            return _mapper.Map<AddressDto>(address);

        }

        public async Task<int> AddAsync(Address model)
        {
            try
            {
                await _dbContext.Addresss.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return model.Id;
        }

        public async Task<int> AddRangeAsync(List<Address> model)
        {
            try
            {
                await _dbContext.Addresss.AddRangeAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }

        public async Task<int> UpdateAsync(int id, Address model)
        {
            try
            {
                var address = await _dbContext.Addresss.FindAsync(id);
                if (address == null)
                    return -1;
                address.Description = model.Description;
                _dbContext.Addresss.Attach(address);
                _dbContext.Entry(address).Property(x => x.Description).IsModified = true;
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
                var address = await _dbContext.Addresss.FindAsync(id);
                if (address != null)
                    _dbContext.Addresss.Remove(address);
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
