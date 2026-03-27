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