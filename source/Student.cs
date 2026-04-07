using System;
using System.Collections.Generic;

namespace assignment2
{
    [Serializable]
    internal class Student
    {
        private int studentId;
        private string name;
        private string email;

        // Generates IDs for students, each one more than last
        private static int s_studentIdGenerator = 0;

        public int StudentId
        {
            get { return studentId; }
            private set { studentId = value; }
        }

        // Uses Course file to get list of courses
        public List<Course> EnrolledCourses { get; } = new List<Course>();

        public string Name
        {
            get { return name; }
            set
            {
                // Validate that student fields aren't empty
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Student name cannot be empty");
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Email cannot be empty");
                email = value;
            }
        }

        public Student(string name, string email)
        {
            StudentId = ++s_studentIdGenerator;
            Name = name;
            Email = email;
        }
    }
}



// Updated code from Nabiha

using System;
using System.Collections.Generic;

namespace assignment2
{
    [Serializable]
    internal class Student
    {
        
        private int StudentID; // changing studentId to StudentID - Nabiha
        private string name;
        private string email;

        // Generates IDs for students, each one more than last
        private static int s_studentIdGenerator = 0;

        public int StudentId
        {
            get { return StudentID; }
            private set { StudentID = value; }
        }

        // Uses Course file to get list of courses
        
        public List<Course> EnrolledCourses { get; } = new List<Course>();

        public string Name
        {
            get { return name; }
            set
            {
                // Validate that student fields aren't empty
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Student name cannot be empty");
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Email cannot be empty");
                email = value;
            }
        }
        
        // College.cs calls AddStudent(string name, string email) which uses this constructor - Nabiha

        public Student(string name, string email)
        {
            StudentId = ++s_studentIdGenerator;
            Name = name;
            Email = email;
        }
        
        // Optional: add DisplayInfo() if needed for menus (College.cs calls DisplayStudents()) - Nabiha 
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {Name}, Email: {Email}, Courses Enrolled: {EnrolledCourses.Count}");
        }

        
        // Fix for loading IDs from file - Nabiha
        public static void SetLastId(int lastId)
        {
            s_studentIdGenerator = lastId;
        }

    }
}
