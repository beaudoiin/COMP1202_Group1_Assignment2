namespace assignment2 {
    internal class Program {
        //Keeping track of the connection between each course and student is handled inside College class whcih handles thse administrative actions.

        //Keep track of all students that have been enrolled at the college
        //static List<Student>? students; //store inside College class
        //Keep track of all courses provided by the college.
        //static List<Course>? courses; // store inside Collage class as 2d array
        /// <summary>
        /// This variable should be changed to true if anything information that would normally be saved is changed. This includes but is not limited to
        ///Adding a student, Adding a course, updating either's information, changing settings, removind records.
        /// Change this directly after the information is Creatued, updated, Deleted, and cleared After save or on load. 
        /// Use this to display a warning on exiting, to confirm if user wants to leave without saving changes.
        /// </summary>
        static bool dataChange = false;

        static void Main( string [ ] args ) {
            //Initialize detials such as UTF8 console encoding, defualt colors for background and foreground. and other such detials.

            //AnimationSequence(); // This is just animated text to introduce the program.

            // Optional, if implementing you need to create an enumerator for the message labels, and use a dictionary to store the texts.
            // Choosing a language loads from XML and overwrites a default englihs dictionary. Dictionarty<messageEnum, string> is the convention to be used for storing the words.
            // Chooselanguage (); 

            //If implementing more options, revert from using Console.ReadKey, to ReadLine and users enter a validated number, otherwise a "More" Option will be needed when a 10th menu is needed. or 11th if you choose to allow "0" as the first option.


            switch ( MainOptions() ) {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddStudent();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    //Addcourse();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    //RegisterStudentToCourse();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    //This an display all courses may be similar. Consider using one method with an enum to deferentiate what is being displayed. Pass appropriate list as paramater and an enum
                    //DisplayAllStudents();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    //This an display all students may be similar. Consider using one method with an enum to deferentiate what is being displayed. Pass appropriate list as paramater and an enum
                    //DisplayAllCourses();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    //same as other two lists
                    //DisplayAllRegistrations();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    //Be sure to include conformation before overwriting data
                    //Include changing a bool flat when data saved. if data not saved, then exit will display a warning.
                    //SaveDate();
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    //Be sure to include conformation before overwriting data
                    //LoiadDate();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Backspace:
                    //Be sure to include conformation before exiting, reminding the user if they want to save.
                    //LoiadDate();
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