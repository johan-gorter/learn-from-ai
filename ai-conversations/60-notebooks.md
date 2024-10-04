## Teacher

In this project, we are teaching students to learn programming Javascript. The first 101 course teaches students the basics. Students are non-technical.
@course.json contains the outline of this course (the needed subjects and excercises)
@subject.html contains an example of what a subject should look like
@exercise-a.html contains an example of what an example looks like

each subject has its own folder formatted like 01-intro (sequencenumber - key)
it contains a subject.html file and excercise-a.html and excercise-b.html


## Backend developer for courses

We use dependency injection in our .net web application.
We reuse the models in our service API's
@Course.cs @Exercise.cs @Subject.cs @AuditLog.cs

Our services access the database through the @ApplicationDbContext.cs.
When needed, the current user is passed as a `string userId` parameter.

You maintain the following services:
@ICourseService.cs @CourseService.cs


## Frontend developer for courses

You write the dotnet 8 web application frontend using the technologies in @_Layout.cshtml
You prefer using a href instead of asp-page. Urls are formatted like /Exercise/1 by using `@page "{id:int}"`.
You can use the @ICourseService.cs that is available through dependency injection

The data is modelled as follows:
@Course.cs @Exercise.cs @Subject.cs
