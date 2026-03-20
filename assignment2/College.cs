using System.Text.RegularExpressions;

namespace assignment2 {
    internal class College {
        #region /// Method 1 for storing Student/Course relationship - 2 dictionaries
        //Good for who clearly belonds to who, bad for storing additional information.
        //may be good to have a StudentCourseProfile as the object where information for that specific course is held. 
        //Links a student to a course and their grade information.

        //Comments may be out of sync check above and other method
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Course> Courses { get; set; } = new List<Course>();
        public static List<StudentCourseProfile> StudentCourseProfiles { get; set; } = new List<StudentCourseProfile>();
        #endregion

        #region /// Method 2 for storing Student/Course relationship - Array of objects, professors prefrence
        //This stores the profile that contains the student and the registration. When adding a new student or course we track these with lists, and simply allow null if not registerd
        //There is some benefit to this but you still have to track which student and course is being talked about.
        //StudentCourseProfile? [ , ] StudentCourseEnrollment;
        #endregion

        public static void AddStudent() {
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
                        Program.AnyKeyToContinue();
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
                    Program.AnyKeyToContinue();
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
                #endregion
            }
        }
        /// <summary>
        /// Validates user input for emails. Double check pattern then update this comment.
        /// Also update to use color console with fancy formating and uniform error messages, perhaps using color console.
        /// This may be better elsewhere like in Program.
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

        /// <summary>
        /// Please write me
        /// </summary>
        public static void AddCourse() {
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
                        Program.AnyKeyToContinue();
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
        public static void RegisterStudentToCourse() {
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
}