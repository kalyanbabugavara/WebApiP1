namespace WebApiP1.Models.DTO
{
    public class TeacherDto
    {
        //define only the data that want to expose 
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }

        public string BranchCode { get; set; }

        public int Exp { get; set; }
    }
}

/* Data transfer objects- used to transfer data b/w layers
 * Clent - DTO - API - Domain model - Database
 * helps to expose only necessary data
 */
