using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace assignment2
{
    [Serializable]
    internal class StudentCourseProfile
    {
        private Student student;
        private Course course;
        private Dictionary<string, float> grades;
        private DateOnly registrationDate;

        //Stores student information in relationship
        public Student Student
        {
            get { return student; }
            private set { student = value; }
        }

        //stores course info
        public Course Course
        {
            get { return course; }
            private set { course = value; }
        }

        //stores grades for assignments, labs, etc.
        public Dictionary<string, float> Grades
        {
            get { return grades; }
            private set { grades = value; }
        }

        //Keeps track of date the student was registered
        public DateOnly RegistrationDate
        {
            get { return registrationDate; }
            private set { registrationDate = value; }
        }

        //Constructor to create student-course relationship
        [JsonConstructor]
        public StudentCourseProfile(Student student, Course course, DateOnly registrationDate)
        {
            Student = student;
            Course = course;
            RegistrationDate = registrationDate;
            grades = new Dictionary<string, float>();
        }
    }
}