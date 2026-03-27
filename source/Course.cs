using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace assignment2
{
    [Serializable]
    internal class Course
    {
        // Define parts of Course
        private int courseId;
        private string courseName;
        private int creditHours;
        private string description;

        // Generates IDs for courses, each one more than last
        private static int s_courseIdGenerator = 0;

        public int CourseId
        {
            get { return courseId; }
            private set { courseId = value; }
        }

        public List<Student> EnrolledStudents { get; } = new List<Student>();

        public string CourseName
        {
            get { return courseName; }
            set
            {
                // Verifies that the section isn't empty
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Course name cannot be empty");
                courseName = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Consider including a description for the course");
                description = value;
            }
        }

        public int CreditHours
        {
            get { return creditHours; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Please list how many hours this course is worth.");
                creditHours = value;
            }
        }

        [JsonConstructor]
        public Course(string courseName, int creditHours, string description)
        {
            CourseName = courseName;
            CreditHours = creditHours;
            CourseId = ++s_courseIdGenerator;
            Description = description;
        }

        public override string ToString()
        {
            return $"Course: {CourseName}, ID: {CourseId}, Credit Hours: {CreditHours}, Number of Enrolled Students: {EnrolledStudents.Count}";
        }
    }
}