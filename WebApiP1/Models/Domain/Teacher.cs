namespace WebApiP1.Models.Domain
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }

        public string BranchCode { get; set; }

        public int Exp { get; set; }

        //Navigation property

        //public Branch Branch { get; set; }


    }
}
