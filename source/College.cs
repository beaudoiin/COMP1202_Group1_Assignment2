/* Name: Nabiha Fahad
Student ID: 101462243 */

using System;
using System.Collections.Generic;
using System.IO;

namespace assignment2
{
    class College
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private bool[,] registrations = new bool[100, 100];

        // ------------------ ADD STUDENT ------------------
        public void AddStudent(string name, string email)
        {
            Student s = new Student(name, email);
            students.Add(s);
            Console.WriteLine($"Student added: {s.StudentId} - {s.Name}");
        }

        // ------------------ ADD COURSE ------------------
        public void AddCourse(string name, int credits, string description = "No description provided")
        {
            Course c = new Course(name, credits, description);
            courses.Add(c);
            Console.WriteLine($"Course added: {c.CourseId} - {c.CourseName}");
        }

        // ------------------ REGISTER STUDENT TO COURSE ------------------
        public void RegisterStudent(int studentId, int courseId)
        {
            int sIndex = students.FindIndex(s => s.StudentId == studentId);
            int cIndex = courses.FindIndex(c => c.CourseId == courseId);

            if (sIndex != -1 && cIndex != -1)
            {
                if (registrations[sIndex, cIndex])
                        {
                            Console.WriteLine("Student already registered in this course.");
                            return;
                        }
                registrations[sIndex, cIndex] = true;
                students[sIndex].EnrolledCourses.Add(courses[cIndex]);
                courses[cIndex].EnrolledStudents.Add(students[sIndex]);
                Console.WriteLine($"Student {students[sIndex].Name} registered for course {courses[cIndex].CourseName}");
            }
            else
            {
                Console.WriteLine("Invalid Student ID or Course ID.");
            }
        }

        // ------------------ DISPLAY STUDENTS ------------------
        public void DisplayStudents()
        {
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Email: {s.Email}");
            }
        }

        // ------------------ DISPLAY COURSES ------------------
        public void DisplayCourses()
        {
            foreach (var c in courses)
            {
                Console.WriteLine($"ID: {c.CourseId}, Name: {c.CourseName}, Credits: {c.CreditHours}");
            }
        }

        // ------------------ DISPLAY REGISTRATIONS ------------------
        public void DisplayRegistrations()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"Student: {students[i].Name} (ID: {students[i].StudentId})");
                for (int j = 0; j < courses.Count; j++)
                {
                    if (registrations[i, j])
                    {
                        Console.WriteLine($"  -> {courses[j].CourseName} (ID: {courses[j].CourseId})");
                    }
                }
            }
        }

        // ------------------ SAVE DATA ------------------
        public void SaveData()
        {
            using (StreamWriter sw = new StreamWriter("students.txt"))
            {
                foreach (var s in students)
                {
                    sw.WriteLine($"{s.StudentId},{s.Name},{s.Email}");
                }
            }

            using (StreamWriter sw = new StreamWriter("courses.txt"))
            {
                foreach (var c in courses)
                {
                    sw.WriteLine($"{c.CourseId},{c.CourseName},{c.CreditHours}");
                }
            }

            using (StreamWriter sw = new StreamWriter("registrations.txt"))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    for (int j = 0; j < courses.Count; j++)
                    {
                        if (registrations[i, j])
                        {
                            sw.WriteLine($"{students[i].StudentId},{courses[j].CourseId}");
                        }
                    }
                }
            }

            Console.WriteLine("Data saved successfully!");
        }

        // ------------------ LOAD DATA ------------------
        public void LoadData()
        {
            students.Clear();
            courses.Clear();
            registrations = new bool[100, 100];
        
            int maxStudentId = 0;
            int maxCourseId = 0;
        
            // -------- LOAD STUDENTS --------
            if (File.Exists("students.txt"))
            {
                foreach (var line in File.ReadAllLines("students.txt"))
                {
                    var parts = line.Split(',');
        
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string email = parts[2];
        
                    Student s = new Student(name, email);
        
                    //  manually set ID
                    typeof(Student).GetProperty("StudentId").SetValue(s, id);
        
                    students.Add(s);
        
                    if (id > maxStudentId)
                        maxStudentId = id;
                }
            }
        
            // -------- LOAD COURSES --------
            if (File.Exists("courses.txt"))
            {
                foreach (var line in File.ReadAllLines("courses.txt"))
                {
                    var parts = line.Split(',');
        
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    int credits = int.Parse(parts[2]);
        
                    Course c = new Course(name, credits);
        
                    typeof(Course).GetProperty("CourseId").SetValue(c, id);
        
                    courses.Add(c);
        
                    if (id > maxCourseId)
                        maxCourseId = id;
                }
            }
        
            //  FIX static counters
            Student.SetLastId(maxStudentId);
            Course.SetLastId(maxCourseId);
        
            // -------- LOAD REGISTRATIONS --------
            if (File.Exists("registrations.txt"))
            {
                foreach (var line in File.ReadAllLines("registrations.txt"))
                {
                    var parts = line.Split(',');
        
                    int studentId = int.Parse(parts[0]);
                    int courseId = int.Parse(parts[1]);
        
                    int sIndex = students.FindIndex(s => s.StudentId == studentId);
                    int cIndex = courses.FindIndex(c => c.CourseId == courseId);
        
                    if (sIndex != -1 && cIndex != -1)
                    {
                        registrations[sIndex, cIndex] = true;
        
                        students[sIndex].EnrolledCourses.Add(courses[cIndex]);
                        courses[cIndex].EnrolledStudents.Add(students[sIndex]);
                    }
                }
            }
        
            Console.WriteLine("Data loaded successfully!");
        }

    }
}
