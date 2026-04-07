
/*
COMP 1202 Assignment 2 - Course Registration System
Name: Nabiha Fahad
Student ID: 101462243
 
This program is a menu-driven console application to manage Students, Courses,
and Registrations. It demonstrates classes, aggregation, 2D array usage, and
file I/O.
*/

using System;

namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            College college = new College();

            // Attempt to load previous data
            college.LoadData();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== College Course Registration System ===");
                Console.WriteLine("1. Add a New Student");
                Console.WriteLine("2. Add a New Course");
                Console.WriteLine("3. Register a Student to a Course");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Registrations");
                Console.WriteLine("7. Save Data");
                Console.WriteLine("8. Load Data");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine(); // For spacing

                switch (input)
                {
                    case "1":
                        AddStudent(college);
                        break;
                    case "2":
                        AddCourse(college);
                        break;
                    case "3":
                        RegisterStudent(college);
                        break;
                    case "4":
                        college.DisplayStudents();
                        break;
                    case "5":
                        college.DisplayCourses();
                        break;
                    case "6":
                        college.DisplayRegistrations();
                        break;
                    case "7":
                        college.SaveData();
                        break;
                    case "8":
                        college.LoadData();
                        break;
                    case "9":
                        Console.WriteLine("Exiting program. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // -------------------- Helper Methods --------------------

        static void AddStudent(College college)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();

            try
            {
                college.AddStudent(name, email);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddCourse(College college)
        {
            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Credit Hours: ");
            if (!int.TryParse(Console.ReadLine(), out int credits))
            {
                Console.WriteLine("Invalid number for credits.");
                return;
            }

            try
            {
                college.AddCourse(name, credits);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RegisterStudent(College college)
        {
            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.WriteLine("Invalid Student ID.");
                return;
            }

            Console.Write("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseID))
            {
                Console.WriteLine("Invalid Course ID.");
                return;
            }

            college.RegisterStudent(studentID, courseID);
        }
    }
}

// Program.cs is the main console application for the College Course Registration System.
//     It creates a College object to manage all students, courses, and registrations.
//     The program displays a menu and uses a while loop to keep running until the user exits.
//     Users can add students/courses, register students to courses, display information, and save or load data.
//     Helper methods handle input validation and call methods in the College class.
// This program demonstrates menu-driven functionality and integrates the 2D array registration system and file I/O.
