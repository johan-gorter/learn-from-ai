using System.Collections.Generic;

namespace LearnFromAI.Models
{
  public class Subject
  {
    public int Id { get; set; }
    public string Key { get; set; }
    public string Headline { get; set; }
    public int Order { get; set; }
    public List<Exercise> Exercises { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
  }
}
