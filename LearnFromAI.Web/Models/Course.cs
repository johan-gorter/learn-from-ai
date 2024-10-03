using System.Collections.Generic;

namespace LearnFromAI.Web.Models
{
  public class Course
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Subject> Subjects { get; set; }
    public string Content { get; set; }
  }
}
