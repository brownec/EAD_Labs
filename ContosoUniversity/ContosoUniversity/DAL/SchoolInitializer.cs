using ContosoUniversity.Models;
using System;
using System.Collections.Generic;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstMidName = "Cliff", LastName = "Browne", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "Stephen", LastName = "Begley", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "Stephanie", LastName = "Courtney", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "Gary", LastName = "Curran", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "John", LastName = "Diez-Daly", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "Gillian", LastName = "Dunne", EnrollmentDate = DateTime.Parse("2011-09-16")},
                new Student{FirstMidName = "Thomas", LastName = "Jones", EnrollmentDate = DateTime.Parse("2012-09-13")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID = 4001, Title = "Enterprise Application Architecture", Credits = 1},
                new Course{CourseID = 4002, Title = "Enterprise Application Design 1", Credits = 1},
                new Course{CourseID = 4003, Title = "Information Management", Credits = 1},
                new Course{CourseID = 4004, Title = "Interactive Media Design", Credits = 1},
                new Course{CourseID = 4005, Title = "Social Media Analysis", Credits = 1},
                new Course{CourseID = 4006, Title = "Project", Credits = 3}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=3, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=4, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=5, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=6, CourseID=4001, Grade=Grade.A},
                new Enrollment{StudentID=7, CourseID=4001, Grade=Grade.A},

                new Enrollment{StudentID=1, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=2, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=3, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=4, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=5, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=6, CourseID=4002, Grade=Grade.B},
                new Enrollment{StudentID=7, CourseID=4002, Grade=Grade.B},

                new Enrollment{StudentID=1, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=3, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=4, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=5, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=6, CourseID=4003, Grade=Grade.A},
                new Enrollment{StudentID=7, CourseID=4003, Grade=Grade.A},
                
                new Enrollment{StudentID=1, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=2, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=3, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=4, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=5, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=6, CourseID=4004, Grade=Grade.C},
                new Enrollment{StudentID=7, CourseID=4004, Grade=Grade.C},
                
                new Enrollment{StudentID=1, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=2, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=3, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=4, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=5, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=6, CourseID=4005, Grade=Grade.D},
                new Enrollment{StudentID=7, CourseID=4005, Grade=Grade.D},
                                
                new Enrollment{StudentID=1, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=2, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=3, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=4, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=5, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=6, CourseID=4006, Grade=Grade.B},
                new Enrollment{StudentID=7, CourseID=4006, Grade=Grade.B}
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}