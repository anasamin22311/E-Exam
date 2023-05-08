namespace E_Exam.Models
{
    public class Chapter
    {
        public Chapter()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
