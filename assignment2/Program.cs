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

using System.Text.RegularExpressions;
using System.Xml.Linq;

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
                    AddStudent();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    AddCourse();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    RegisterStudentToCourse();
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
        static void AddStudent() {
            //main loop for user being able to add multiple students, It may be better to ask them how many students they want to add or see note ate buttom near confirmation
            //Perhaps its also good for no conformation and just reminding them at the start of each itteration they can type "exit" at any time to escape, or we could use :q!
            //which is mostly universal except languages that dont use q for quit, like chinese. :q!
            while ( true ) {
                //Display a heading to instruct the user
                //Run function for getting name,
                //Run function with REGEX to get email, must contain @ and .
                //Store data as new student
                string name;
                #region >>> ///Validate user input
                while ( true ) {
                    Console.WriteLine( "(Type exit to abort) Enter the name of the student: " );
                    name = Console.ReadLine().Trim();
                    //this appears twice, could be made into a function here, but will still need an if statement to return after the function returns, so not much savings.
                    //This allows the user to exit
                    if ( name == "exit" ) {
                        Console.WriteLine( "Adding student aborted!" );
                        AnyKeyToContinue();
                        return;
                    }
                    //Valid email! Horray
                    if ( !string.IsNullOrWhiteSpace( name ) )
                        break;
                    Console.WriteLine( "(Bad Input!) Name can not be empty or white spaces." );
                }
                #endregion

                #region >>> ///Validate email
                string? emailParse = GetEmail();
                //This allows the user to exit
                if ( emailParse == "exit" ) {
                    Console.WriteLine( "Adding student aborted!" );
                    AnyKeyToContinue();
                    return;
                }
                string email = string.IsNullOrWhiteSpace( emailParse ) ? "None provided" : emailParse;
                #endregion

                #region >>> ///Create the student and add to List
                College.Students.Add( new Student( name, email ) );
                Console.WriteLine( "Student Added" );
                //Autosave may be used here, but as the present save method is, this will be laggy for large files as it rewrites everything.
                //for now left as user going to main menu to save.
                //Same note as above, perhaps this is not needed, just allow to loop and expect user to type exit or :q! when done as a name or email.
                Console.WriteLine( "Would you like to add another student?" );
                Console.WriteLine( "(Y or Enter for yes) OR (N or ESC for no)" );
                while ( true ) {
                    ConsoleKey key = Console.ReadKey().Key;
                    if ( key == ConsoleKey.N || key == ConsoleKey.Escape ) {
                        return;
                    }
                    if ( key == ConsoleKey.Y || key == ConsoleKey.Enter ) {
                        //Please choose a better label then below, none may be needed
                        Console.WriteLine( "Add another student:" );
                        break;
                    }
                }
            }
            /// <summary>
            /// Validates user input for emails. Double check pattern then update this comment.
            /// Also update to use color console with fancy formating and uniform error messages, perhaps using color console.
            /// </summary>
            /// <returns>String with the users email</returns>
            static string? GetEmail() {
                string? email = null;
                //simple regex pattern found at https://www.regular-expressions.info/email.html
                string emailRulePattern = "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}$.";
                Regex emailRule = new( emailRulePattern, RegexOptions.IgnoreCase );
                while ( true ) {
                    Console.WriteLine( "Rules related to email:" );
                    Console.WriteLine( "Email must contain an @ sign and a valid domain. Entering an empty string or all spaces will register the student with no email." );
                    Console.WriteLine( "(Type exit to abort) Enter the users email: " );
                    email = Console.ReadLine();
                    if ( email == "exit" ) {
                        return "exit";
                    }
                    if ( emailRule.IsMatch( email ) )
                        return email;
                    else if ( string.IsNullOrWhiteSpace( email ) ) {
                        return null;
                    }
                    Console.WriteLine( "(Bad Input!) This is not a proper email, please try again" );
                    Console.WriteLine( "Press any key to continue" );
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Please write me
        /// </summary>
        static void AddCourse() {
            while ( true ) {

                //Instructions (populat emissing code)

                #region >>> ///Validate user input
                // this code is reused for adding a student, we can make this a method and use a label for "student" that we pass into the method, and get the name out.
                // However the label must be langauge neutral, I tend to follow this convention:
                // (Type exit to abort) (Student) Enter the name: 
                // or
                // (Type exit to abort) Enter the name: 
                // The above helps to seperate due to different langages grammer
                string name;
                while ( true ) {
                    Console.WriteLine( "(Type exit to abort) Enter the name of the course: " );
                    name = Console.ReadLine().Trim();
                    //this appears twice, could be made into a function here, but will still need an if statement to return after the function returns, so not much savings.
                    //This allows the user to exit
                    if ( name == "exit" ) {
                        Console.WriteLine( "Adding student aborted!" );
                        AnyKeyToContinue();
                        return;
                    }
                    //Valid email! Horray
                    if ( !string.IsNullOrWhiteSpace( name ) )
                        break;
                    Console.WriteLine( "(Bad Input!) Name can not be empty or white spaces." );
                }
                #endregion

                //Prompt for credits, (try parse int)

                //Store

                //Optional save

                //Confirmation or let loop, and above inputs use exit or :q! to exit (note this in instructions)
            }
        }
        static void RegisterStudentToCourse() {
            //Dont forget to allow the user to type exit or :q! to abort, and consider after each student if you want a conformation to add another student.
            // no conformation? Add in instructions to end adding studentCourse relations, type the above.
            while ( true ) {


                //multi choice, >>> Enter Students Id, View list of Student ID, Search Students by name or by email. This is more adavanced, can be skipped. Although I would do it lol
                //Prompt for studentID

                //multi choice, >>> Enter Course Id, View list of Student ID, Search Students by name or by email. This is more adavanced, can be skipped. Although I would do it lol
                // Prompt for CourseId

                //Add to StudentCourseProfile in College.StudentCourseProfiles.
            }
        }
    }