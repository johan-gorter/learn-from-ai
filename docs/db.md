# Database Schema Overview

## Tables and Relationships

### 1. User Table
The `User` table is provided by ASP.NET Identity and contains information about the users of the application.

| Column Name       | Data Type | Description                  |
|-------------------|-----------|------------------------------|
| Id                | string    | Primary key                  |
| UserName          | string    | User's username              |
| Email             | string    | User's email address         |
| PasswordHash      | string    | Hashed password              |
| ...               | ...       | Other Identity fields        |

### 2. Course Table
The `Course` table contains information about the courses available in the application.

| Column Name       | Data Type | Description                  |
|-------------------|-----------|------------------------------|
| Id                | int       | Primary key                  |
| Title             | string    | Title of the course          |

#### Relationships
- One-to-Many with `Subject` table (Course.Id -> Subject.CourseId)

### 3. Subject Table
The `Subject` table contains information about the subjects within a course.

| Column Name       | Data Type | Description                  |
|-------------------|-----------|------------------------------|
| Id                | int       | Primary key                  |
| Key               | string    | Unique key for the subject   |
| Headline          | string    | Headline of the subject      |
| Order             | int       | Order of the subject         |
| CourseId          | int       | Foreign key to `Course`      |

#### Relationships
- Many-to-One with `Course` table (Subject.CourseId -> Course.Id)
- One-to-Many with `Exercise` table (Subject.Id -> Exercise.SubjectId)

### 4. Exercise Table
The `Exercise` table contains information about the exercises within a subject.

| Column Name       | Data Type | Description                  |
|-------------------|-----------|------------------------------|
| Id                | int       | Primary key                  |
| Key               | string    | Unique key for the exercise  |
| Headline          | string    | Headline of the exercise     |
| Order             | int       | Order of the exercise        |
| SubjectId         | int       | Foreign key to `Subject`     |

#### Relationships
- Many-to-One with `Subject` table (Exercise.SubjectId -> Subject.Id)

### 5. AuditLog Table
The `AuditLog` table contains information about user actions related to subjects and exercises.

| Column Name       | Data Type | Description                  |
|-------------------|-----------|------------------------------|
| Id                | int       | Primary key                  |
| UserId            | string    | Foreign key to `User`        |
| SubjectId         | int?      | Foreign key to `Subject`     |
| ExerciseId        | int?      | Foreign key to `Exercise`    |
| Action            | string    | Action performed (e.g., "Start", "Complete", "Skip") |
| Timestamp         | DateTime  | Timestamp of the action      |

#### Relationships
- Many-to-One with `User` table (AuditLog.UserId -> User.Id)
- Many-to-One with `Subject` table (AuditLog.SubjectId -> Subject.Id)
- Many-to-One with `Exercise` table (AuditLog.ExerciseId -> Exercise.Id)

### Summary of Relationships
- A `Course` can have multiple `Subjects`.
- A `Subject` belongs to one `Course` and can have multiple `Exercises`.
- An `Exercise` belongs to one `Subject`.
- An `AuditLog` entry is associated with a `User` and optionally with a `Subject` and/or `Exercise`.

This schema ensures that each course can have multiple subjects, and each subject can have multiple exercises, with explicit ordering maintained for subjects and exercises. Additionally, user actions related to subjects and exercises are logged in the `AuditLog` table.

