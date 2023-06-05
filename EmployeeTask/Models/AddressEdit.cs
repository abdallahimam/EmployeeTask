using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Models
{
    public class AddressEdit
    {
        public int Id { get; set; }

        [RegularExpression(@"^(.*\S.*)$", ErrorMessage = "White spaces not allowed.")]
        public string Description { get; set; }

    }
}
