namespace LearnFromAI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Headline { get; set; }
        public int Order { get; set; }  // Add this property
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string Content { get; set; }
    }
}
