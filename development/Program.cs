namespace assignment2 {
    internal class Program {
        //Keeping track of the connection between each course and student is handled internally inside those respective classes.

        //Keep track of all students that have been enrolled at the college
        static List<Student>? students;
        //Keep track of all courses provided by the college.
        static List<Course>? courses;

        static void Main( string [ ] args ) {
            switch ( MainOptions() ) {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddStudent();
                    break;
            }
        }
        /// <summary>
        /// Main menu for the programing, handling the logic based on user interaction.
        /// </summary>
        static void MainMenu() { }
        /// <summary>
        /// Displays a menu for the user to make a choice and returns the key the user pressed. This does not handle incorrect keys, decision logic (such as switch) handles that in the MainMenu.
        /// </summary>
        static ConsoleKey MainOptions() {
            ConsoleKey Key = Console.ReadKey().Key;
            return Key;
        }
        static void AddStudent() {
            //Display a heading to instruct the user
            //Run function for getting name,
            //Run function with REGEX to get email, must contain @ and .
            //Store data as new student
        }

    }
}
