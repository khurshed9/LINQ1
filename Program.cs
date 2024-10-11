

using HomeTaskLINQ2;

List<Student> students = new List<Student>
{
    new Student { StudentId = 1, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) },
    new Student { StudentId = 2, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 25) },
    new Student { StudentId = 3, Name = "Charlie", DateOfBirth = new DateTime(2001, 3, 10) }
};


List<Course> courses = new List<Course>
{
    new Course { CourseId = 101, Title = "Mathematics", Credits = 4 },
    new Course { CourseId = 102, Title = "Computer Science", Credits = 3 },
    new Course { CourseId = 103, Title = "Physics", Credits = 4 }
};


List<Enrollment> enrollments = new List<Enrollment>
{
    new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 15) },
    new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 20) },
    new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 18) },
    new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 103, EnrollmentDate = new DateTime(2023, 1, 22) },
    new Enrollment { EnrollmentId = 5, StudentId = 3, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 25) },
    new Enrollment { EnrollmentId = 6, StudentId = 3, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 30) }
};

//1
/*var query1 = from s in students
    join e in enrollments on s.StudentId equals e.StudentId
    join c in courses on e.CourseId equals c.CourseId
    where c.Title == "Mathematics"
    select  s;

foreach (var q1 in query1)
{
    Console.WriteLine(q1.StudentId + " "+ q1.Name + " " + q1.DateOfBirth.ToShortDateString());
}*/

//2
/*var query2 = from c in courses
    join e in enrollments on c.CourseId equals e.CourseId
    join s in students on e.StudentId equals s.StudentId
    where s.Name == "Charlie"
    select c;

foreach (var q2 in query2)
{
    Console.WriteLine(q2.CourseId + " " + q2.Title + " " + q2.Credits);
}*/

//3
/*var q3 = students
    .Where(s => enrollments.Count(e => e.StudentId == s.StudentId) > 1)
    .Select(s => new
    {
        s.StudentId,
        s.Name,
        s.DateOfBirth,
        CourseCount = enrollments.Count(e => e.StudentId == s.StudentId)
    });

foreach (var student in q3)
{
    Console.WriteLine($"{student.StudentId} {student.Name} {student.DateOfBirth.ToShortDateString()} - Enrolled in {student.CourseCount} courses");
}*/

//4


//6
/*var q6 = from s in students 
    join e in enrollments on s.StudentId equals e.StudentId
    join c in courses on e.CourseId equals c.CourseId
    group c by new { s.StudentId, s.Name } into g
    select new
    {
        g.Key.StudentId,
        g.Key.Name,
        TotalCredits = g.Sum(c => c.Credits)
    };

foreach (var student in q6)
{
    Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Total Credits: {student.TotalCredits}");
}*/

//7
/*var query7 = from c in courses
    join e in enrollments on c.CourseId equals e.CourseId into courseEnrollments
    select new
    {
        CourseId = c.CourseId,
        Title = c.Title,
        StudentCount = courseEnrollments.Count()
    };

foreach (var course in query7)
{
    Console.WriteLine($"Course ID: {course.CourseId}, Title: {course.Title}, Student Count: {course.StudentCount}");
}*/

//8
/*var query8 = from c in courses 
             join e in enrollments on c.CourseId equals e.CourseId
             join s in students on e.StudentId equals s.StudentId
             where s.Name == "Bob" && e.StudentId != e.CourseId 
             select c;

foreach (var q8 in query8)
{
    Console.WriteLine(q8.CourseId + " " + q8.Title + " " + q8.Credits);
}*/