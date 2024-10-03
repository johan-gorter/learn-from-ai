using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using LearnFromAI.Web.Models;

namespace LearnFromAI.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      context.Database.EnsureCreated();

      // Check if the database has already been seeded
      if (context.Courses.Any())
      {
        return; // Database has been seeded
      }

      // Read the course.json file
      string courseJson = File.ReadAllText("Seed/Javascript-101/course.json");

      // Add options for more lenient deserialization
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
      };

      // Use the options when deserializing
      var courseData = JsonSerializer.Deserialize<CourseData>(courseJson, options);

      // Add null check and logging
      if (courseData?.Subjects == null)
      {
        Console.WriteLine("Error: Failed to deserialize course data. Subjects is null.");
        Console.WriteLine($"JSON content: {courseJson}");
        // Optionally, throw an exception or handle the error as appropriate
        return;
      }

      // Create the course
      var course = new Course
      {
        Title = courseData.Title,
        Content = courseData.Content
      };

      context.Courses.Add(course);

      // Add subjects and exercises
      for (int i = 0; i < courseData.Subjects.Length; i++)
      {
        var subjectData = courseData.Subjects[i];
        var subject = new Subject
        {
          Key = subjectData.Key,
          Headline = subjectData.Headline,
          Order = i + 1,
          Course = course,
          Content = File.ReadAllText($"Seed/Javascript-101/{(i + 1):D2}-{subjectData.Key}/subject.html")
        };

        context.Subjects.Add(subject);

        for (int j = 0; j < subjectData.Exercises.Length; j++)
        {
          var exerciseData = subjectData.Exercises[j];
          var exercise = new Exercise
          {
            Key = exerciseData.Key,
            Headline = exerciseData.Headline,
            Order = j + 1,
            Subject = subject,
            Content = File.ReadAllText($"Seed/Javascript-101/{(i + 1):D2}-{subject.Key}/exercise-{(char)('a' + j)}.html")
          };

          context.Exercises.Add(exercise);
        }
      }

      context.SaveChanges();
    }
  }

  // Helper classes for JSON deserialization
  class CourseData
  {
    public string Title { get; set; }
    public string Content { get; set; }
    public SubjectData[] Subjects { get; set; }
  }

  class SubjectData
  {
    public string Key { get; set; }
    public string Headline { get; set; }
    public ExerciseData[] Exercises { get; set; }
  }

  class ExerciseData
  {
    public string Key { get; set; }
    public string Headline { get; set; }
  }
}
