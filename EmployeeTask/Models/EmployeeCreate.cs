using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Models
{
    public class EmployeeCreate
    {
        public int Id { get; set; }

        [RegularExpression(@"^(.*\S.*)$", ErrorMessage = "White spaces not allowed.")]
        public string Name { get; set; }

        [Range(21, int.MaxValue, ErrorMessage = "Enter age greater than 20")]
        //[RegularExpression("^[2-9][0-9]{2,3}$", ErrorMessage = "Age must be greater than 20.")]
        public float Age { get; set; }

        //public string[] Address { get; set; }
    }
}
