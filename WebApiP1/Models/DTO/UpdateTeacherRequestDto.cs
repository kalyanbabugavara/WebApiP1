using System.ComponentModel.DataAnnotations;

namespace WebApiP1.Models.DTO
{
    public class UpdateTeacherRequestDto
    {
        [Required]
        public string TeacherName { get; set; }

        [MinLength(2, ErrorMessage = "Code has to be min of 2 char")]
        [MaxLength(4, ErrorMessage = "Code has to be max of 4 char")]
        public string BranchCode { get; set; }

        [Range(0, 50)]
        public int Exp { get; set; }
    }
}
