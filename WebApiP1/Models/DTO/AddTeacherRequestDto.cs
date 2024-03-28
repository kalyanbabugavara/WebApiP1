using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace WebApiP1.Models.DTO
{
    public class AddTeacherRequestDto
    {
        [Required]
        public string TeacherName { get; set; }

        [MinLength(2, ErrorMessage = "Code has to be min of 2 char")]
        [MaxLength(4, ErrorMessage = "Code has to be max of 4 char")]
        public string BranchCode { get; set; }

        [Range(0, 50)]
        public int Exp { get; set; }

        /*Required: Specifies the field is required
        Range: Specifies the minimum and maximum value allowed
        MinLength: Specifies the minimum length of a string
        MaxLength: Specifies the maximum length of a string
        Compare: Compares 2 properties of a model.For example, compare Email and ConfirmEmail properties
        RegularExpression: Validates if the provided value matches the pattern specified 
        by the regular expression*/

    }
}
