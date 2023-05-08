namespace E_Exam.Models
{
    public class StudentRank
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Level Level { get; set; }
        public int Rank { get; set; }
        public string UserId { get; set; }
        public int LevelId { get; set; }
    }
}
