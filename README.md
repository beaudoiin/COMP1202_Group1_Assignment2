# COMP1202_Group1_Assignment2

# Members Responsabilities
* **Nabiha**
  * College Class
  * Program.cs main menu
  * Documentation related to College Class and Program Class
  *  Final Code Review
    
* **Jax**
//Ensure exceptions are custom names, thus we can use those exceptions in validation logic, and exceptions msg wont be used to send to user, so instead of gussing what exception is thown
//we can use a specific name and then format the message to the user using langauge ditionary, coloring and formating.
  * ✅ Student Class  _(custom exceptions with proper naming required)_
  * ✅ Course Class _(custom exceptions with proper naming required)_
  * ✅ StudentCourseProfile _(Just needs to validate registration dates)  (custom exceptions with proper naming required)_
  *  Documentation related to Student Class, Course Class, and StudentCourseProfile class
  *  Final Code Review
    
* **Eric** (Example list, to be discussed)
  * DisplayAll
  * SecureFile class
  * Documentation related to DisplayAll Class, SecureFile Class, GitHub, etc.
  * Final Code Review
  * Documentation final review Oversight
  * ✅ Running the Git Hub
  * ✅ Provided Refrence code for College.cs, Student.cs, Course.cs, StudenCourseProfile.cs and Program.cs
  * EXTENDED FUNCTIONALITY:
       * Various Language support
       * ✅ ConsoleColor.cs for improved coloring
       * Enumerators for tracking langauges
       * AnimatedIntro
       * ✅ AnyKeyToContinue Conformation
  
**Currently there are three folders:**

 1. assignment2: Actual acceptable code for the project refrence can go here. If you want to test some specifics that can be here too
    This folder exists becuase it was going to be the origonal program, but too much code was solved by one handsome ambitious member, se the new project folder is just "source".

 2. Documentation: This is the documentation file and any collected resources that we need for the completion and presentation of this project. Some examples may be articles about how to do specific coding methods or the actual document we prepare for the professor.

 3. Reference code, similar to assignment 2 we may want to incorporate, which is not ready or not fully decided it should go in. For example, I added a ColorConsole class, which replaces Console. Write and writeLine. This is not incorporated because it currently requires enums to set the colors, a dictionary for the error message, and is a replacement for ANSI escape codes, which may be the way we want to go instead. Other such codes are in there; take a look.

 4. Main folder, for these four folders and the readme. We may add other project-wide READMEs, like if each contributor wants **[TheirName].md** to display a running list of what they have implemented, are in charge of, or their thoughts.
 5. source, this is the folder of the code we are all contributing too. The final files for submission should be found and used here when submitting.

  # Current updates

  # Eric's Notes
  * Added a source file so we can start form scratch so each member can contribute evenly.  
  * Added some classes, and a bit of an outline, code needs to be refined. There is a lot going on but generally speaking there is:
  * The main program Program.cs which contains the main menu as a sample, and a couple minimalist functions such as adding and student. Mostly this is barebones.
  * SecureFile.cs for saving files either encrypted or not (searlized JSON)
  * Student.cs, Course.cs, StudentCourseProfile.cs these are the main data points. These all need to be serialized and saved to disk.
  * College.cs is the housekeeping class, it is static so don't make any objects. We use this to store the students list, and course list and profile. I think this needs to be searlized too. the three lists. and also saved
  * ColorConsole.cs a custom class used similar to Console.WriteLine, now you can use ColorConsole.Write and WriteLine. you pass it a msg, and if you want optionally you can pass it a foreground color, a background color, individually or as an array. You can also state if you want the message to wait for user aknowldgment (anykey, using readkey) and also you can use readLine colored. there is another flag that can reset the color, or allow the color to stay changed, (This can frustrating if you forget to set it back, but keeps code cleaner)
  * The above ColorConsole is aimed to reduce tons and tons for Console.foreground being visible. it keeps it simplified. I stored colors in a dictionary and used an enum as a key this way I just use the same colors for the same type of message, and can change in that master dictionary or create themes if needed.
  * ProgramAnimationMethods, this declares a method for using Thread.sleep and clearing the console buffer if keys were pressed (important). Also, there is an animated intro of ascii art and title, (depends on Thread.sleep) from my assignment 1, we can retrofit for our program if we want.
  * NamespaceScopeEnumerators.cs This is just taking any enum we use and placing it in a seperate file. This means its still int he Program class (our main program) but the class is now defined everwhere as partial and split into different files.
  * Aboce Enums can be used for color dictionaries, language dictionaries, flags for method states like reusing for Displayall studentrs / courses, entering name for student/course. Increases reusability
  * Langaugefolder and ProgramLangaugeMethods.cs, these are specifically for adding multi-lingual support. You will need to carefully read the comment in fr.xml and READMELangauge.md, and also the class its self to get a better understanding of the structure.
  * ProgramMessagingMethods.cs, this stores some messaging functions found within the main Program. These are just helpers. Currently its just a method that prompts the user to press any key to continue. We could place our colorConsole.cs in here, but I this is how I did it. This may not be the neatest, we could just dump it back into Program.cs
  * Refrences >> This is just some files for us to pull out some techniques I used. Currently I have a model for config, and various things I did in assignment one.
  * Refrence >> ViewTransactionsListExample.cs >> This is the method I used for displaying in a very structured and formated way my transactions in assignment 1. It makes colums using console cursor position based on LINQ checking the longest variable being displayed per column. The description is least important and truncated. Also it runs a test for languages like chinese where special characters report taking one cell but really take more then 1 cell. There is also a flag for changing states of what is displayed and resevies a filtered list which is condionally sorts. This also provided three modes, List view (one giant scrollable list), Pager view, which is wy the code is a bit more robust, or both (never clears the pager basically)
  * Refrence >> ViewTransactionsListExample.cs >> Also this uses my custom dictionary and enums, so it may be a bit convoluted, so rely on asking me questions or the comments. it is a Text User Interface (TUI) we may want to incorperate into our program.
  * Refrence >> Assignment1Variousmethods.cs >> This one as some important ones like searching by amount, by date, by catergory. we can change it to search by date for registration, by name or by email. It gives some examples using LINQ, returns filtered lists and then passes to "ViewTransactionsList".

# Any additional information request on what i did will need to be directed to me, because I get that it may look confusing at this point, as there is a lot of partialy implimented data.


Populate this folder as group members' collaboration and notes.
Current notes:
Please use ColorConsole.Write, ColorConsole.WriteLine, ColorConsole.ReadLine for messages. the first paramater for Writes is a strung for message, after that are 2index array of ConsoleColor[] for fg, bg.
Method is available for reading the paramaters availble.
Secondly message should be formatted like this:
 enum MessageEnum {
            #region >>> // System
            System_AnyKeyToContinue,
            System_AnyKeyToExit,
            System_YToQuitProgram,
            System_NoReleventTransactions,
   #endregion
            #region >>> // System instructions
            SystemInstructions_AnyKeyToAck,
            SystemInstructions_EscapeOrBackspace,
            SystemInstructions_ToExitOrAbort,
            SystemInstructions_InputYearForSummary,
            SystemInstructions_InputMonthForSummary,
            SystemInstructions_Abort,
               #endregion
               }
               As an example, then the message is found in
               
                static Dictionary<MessageEnum, string> defaultEnglishMessages = new() {
            { MessageEnum.System_AnyKeyToContinue, "Any key to continue" },
            }
            This is one entry, the enum must be found in Messageenum, and the message Any Key to continue will be translated to other languages.
            we will then migrate that list over to (ill handle the migrating)
            
              //Creates an empty dictionary to populate the active language into
        public static Dictionary<MessageEnum, string> messageOutput = new();

        And also the color for the ColorConsole uses an enuma nd dictionary of colors like so:
        

    /// <summary>
    /// Enum for pointing to colors based on groups in the dictionary colorByGroup.
    /// </summary>
    enum ColorGroup {
        Default,
        SystemWarning,
        SystemError,
        SystemInstructions,
        SystemInstructionsGray,
        SystemPromptHint,
        SystemPromptInstructions,
        MenuHeadings,
        MenuItems,
        Success,
        Header,
        InputStyleA,
        InputStyleText
    }
public static Dictionary<ColorGroup, ConsoleColor [ ]> colorByGroup = new() {
            {ColorGroup.Default, [ConsoleColor.White, ConsoleColor.Black ] },
            {ColorGroup.SystemWarning, [ConsoleColor.Red, ConsoleColor.Black ] },

            {ColorGroup.SystemError, [ConsoleColor.Red, ConsoleColor.White ] },
            {ColorGroup.SystemInstructions, [ConsoleColor.Cyan, ConsoleColor.Black ] },
            {ColorGroup.SystemInstructionsGray, [ConsoleColor.Gray, ConsoleColor.Black ] },
            {ColorGroup.MenuHeadings, [ConsoleColor.Cyan, ConsoleColor.Black ] },
            {ColorGroup.MenuItems, [ConsoleColor.Green, ConsoleColor.Black ] },
            {ColorGroup.Success, [ConsoleColor.Black, ConsoleColor.Yellow ] },
            {ColorGroup.Header, [ConsoleColor.Yellow, ConsoleColor.Black ] },
            {ColorGroup.InputStyleA, [ConsoleColor.Black, ConsoleColor.White ] },
            {ColorGroup.InputStyleText, [ConsoleColor.Yellow, ConsoleColor.Black ] },
            {ColorGroup.SystemPromptHint, [ConsoleColor.Gray, ConsoleColor.Black ] },
            {ColorGroup.SystemPromptInstructions, [ConsoleColor.Cyan, ConsoleColor.Black ] }
        };

            
