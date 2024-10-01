using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public Course Course { get; set; }
    public string Content { get; set; }
  }
}
