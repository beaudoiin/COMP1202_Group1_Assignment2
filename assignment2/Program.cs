/* #####################################################################################################
 * ################################### College Application #############################################
 * #####################################################################################################

 * ######### Created By #############
 * Nabiha fahad     GBP ID: 101462243
 * Jax Hobbs        GBP ID: 101360158
 * Eric Beaudoin    GBP ID: 101462947
 * ##################################
 * 
 * #####################################################################################################
 * ##### General Collaberation Notes To Be Updated Or Deleted as Needed and before file submission #####
 * #####################################################################################################
 * 
 * Please read the commends carefully and familiarize your self with the code. I am currently writing
 * the code to get us started untill I hear back from you guys. We can omit features if needed, or start
 * fresh if you guys so prefer. This is an attempt at a robust software that provides a TUI experience
 * for the user. The aim is for practical deployment.
 * 
 * Most of this code is borrowed or used from my Assignment 1, as of 3/18/2026
 * 
 * #####################################################################################################
 * ######################################## Other general notes ########################################
 * #####################################################################################################
 * 
 * There may be a lot to take in, maybe not. But it sure is fun! :D
 * 
 */

namespace assignment2 {
    /// <summary>
    /// Man program defined as partial for splitting some methods into other files. Merges back at compile time
    /// </summary>
    internal partial class Program {
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

        //File names for loading and saving various files, you can adjust as needed.
        static string s_studentFileName = @"students.dat";
        static string s_courseFileName = @"courses.dat";
        static string s_studentCourseFileName = @"studentCourseRelation.dat"; //Debating name
        static string s_configFile = "settings.config";

        //Specify lists and dictionaries here related to storing objects at main program scope. Currently handled by the college class.
        //nothing yet

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
                    College.AddStudent();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    College.AddCourse();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    College.RegisterStudentToCourse();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    //This an display all courses may be similar. Consider using one method with an enum to deferentiate what is being displayed. Pass appropriate list as paramater and an enum
                    //Please see the "ViewtransactionListExample.cs" to see an example on how to format the list dynamically based on data length and consoleWidth. Text User Interface (TUI)
                    //DisplayAllStudents();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    //This an display all students may be similar. Consider using one method with an enum to deferentiate what is being displayed. Pass appropriate list as paramater and an enum
                    //Please see the "ViewtransactionListExample.cs" to see an example on how to format the list dynamically based on data length and consoleWidth. Text User Interface (TUI)

                    //DisplayAllCourses();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    //same as other two lists
                    //Please see the "ViewtransactionListExample.cs" to see an example on how to format the list dynamically based on data length and consoleWidth. Text User Interface (TUI)
                    //DisplayAllRegistrations();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    //Be sure to include conformation before overwriting data
                    //Include changing a bool flat when data saved. if data not saved, then exit will display a warning.
                    //This is going to be a method working with the SecureFile class
                    //SaveData();
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    //Be sure to include conformation before overwriting data
                    //This is going to be a method working with the SecureFile class

                    //LoadData();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Backspace:
                    //Be sure to include conformation before exiting, reminding the user if they want to save.
                    System.Environment.Exit( 0 );
                    break;
            }
        }

        /// <summary>
        /// Displays a menu for the user to make a choice and returns the key the user pressed. This does not handle incorrect keys, decision logic (such as switch) handles that in the MainMenu.
        /// </summary>
        static ConsoleKey MainOptions() {
            ConsoleKey Key = Console.ReadKey().Key;
            return Key;
        }
    }
}