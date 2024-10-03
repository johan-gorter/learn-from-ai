using System;
using System.Collections.Generic;

namespace LearnFromAI.Web.Models
{
  public class AuditLog
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int? SubjectId { get; set; }
    public int? ExerciseId { get; set; }
    public AuditAction Action { get; set; }
    public DateTime Timestamp { get; set; }
  }

  public enum AuditAction
  {
    Start,
    Complete,
    Skip
  }
}
