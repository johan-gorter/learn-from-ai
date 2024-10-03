using System.Text.Json.Serialization;

namespace LearnFromAI.Web.Models
{
  public class Exercise
  {
    public int Id { get; set; }
    public string Key { get; set; }
    public string Headline { get; set; }
    public int Order { get; set; }  // Add this property
    public int SubjectId { get; set; }
    [JsonIgnore]
    public Subject Subject { get; set; }
    public string Content { get; set; }
  }
}
