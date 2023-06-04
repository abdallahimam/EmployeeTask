using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Dtos
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
