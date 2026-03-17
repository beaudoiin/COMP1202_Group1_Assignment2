using Assignment1;

namespace Assignment2 {
    internal class Main {
        #region >>> /// Main menu and related methods
        /// <summary>
        /// Initializes the console application and presents the main menu for user interaction.
        /// </summary>
        /// <remarks>This method manages the application's main loop, allowing users to access transaction
        /// management, budgeting, reporting, and options menus. It also handles language selection and file loading
        /// based on user preferences.</remarks>
        /// <param name="args">No args used</param>
        static void Main( string [ ] args ) {

            Console.CursorVisible = false;
            Thread.Sleep( 50 );
            Console.ForegroundColor = colorByGroup [ ColorGroup.Default ] [ 0 ]; //Console Color Default Set
            Console.BackgroundColor = colorByGroup [ ColorGroup.Default ] [ 1 ]; //incase color/information from previous program carried over
            introAnimation();
            //Load file logic and menu
            LoadFileMenu();
            Console.Write( "\x1b[3J" ); Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Enable displaying other languages
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //Main Menu Logic and Input Validation
            while ( true ) {
                Console.Write( "\x1b[3J" ); Console.Clear();
                //Display menu choices
                MainMenuChoice();
                switch ( Console.ReadKey( intercept: true ).Key ) {
                    //Transaction Menu
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        TransactionManagementMenu();
                        break;
                    //Budget Menu
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        BudgetMenu();
                        break;
                    //Reports & Summary
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        ReportAndSummaryMenu();
                        break;
                    //Options
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        OptionsMenu();
                        break;
                    //Save transactions when option is set to not save on every Transaction and Budget update. (Good for reducing lag, bad for data loss)
                    case ConsoleKey.D5 when !saveOnEveryTransaction:
                    case ConsoleKey.NumPad5 when !saveOnEveryTransaction:
                        LoadFile();
                        break;
                    //Load transactions when option is set to not save on every Transaction and Budget update. (Assumes file only needs to be loaded on startup)
                    case ConsoleKey.D6 when !saveOnEveryTransaction:
                    case ConsoleKey.NumPad6 when !saveOnEveryTransaction:
                        WriteTransactionsAndBudget( BudgetOrTransaction.Transaction );
                        break;
                    //Exit program with confirmation
                    case ConsoleKey.Escape:
                    case ConsoleKey.Backspace:
                        Console.WriteLine();
                        Console.WriteLine( messageOutput [ MessageEnum.System_YToQuitProgram ] );
                        if ( Console.ReadKey( intercept: true ).Key == ConsoleKey.Y ) {
                            ColorConsole.WriteLine( messageOutput [ MessageEnum.Label_Exit ], colorByGroup [ ColorGroup.SystemWarning ], ColorAfterFg: ConsoleColor.White, ColorAfterBg: ConsoleColor.Black, WaitForAcknowledgment: true );
                            Environment.Exit( 0 );
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the main menu options for the application, including transaction management, budget tools, reports,
        /// and options, while conditionally showing save and load options based on the auto-saving setting.
        /// </summary>
        /// <remarks>This method formats and outputs the menu items to the console, providing users with a
        /// clear set of choices. The display of save and load options is dependent on the application's auto-saving
        /// configuration to avoid user confusion.</remarks>
        private static void MainMenuChoice() {
            ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.MainMenu_Header ]} {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", MenuHeadings );
            ColorConsole.WriteLine( "\t1. " + messageOutput [ MessageEnum.MainMenu_TransactionManagement ], MenuItemColor, ResetColorAfter: false );
            ColorConsole.WriteLine( "\t2. " + messageOutput [ MessageEnum.MainMenu_BudgetTools ] );
            ColorConsole.WriteLine( "\t3. " + messageOutput [ MessageEnum.MainMenu_ReportsAndSummary ] );
            ColorConsole.WriteLine( "\t4. " + messageOutput [ MessageEnum.MainMenu_Options ] );
            // Only show save and load options if the user has turned off auto saving to prevent confusion, since these options are not needed when auto saving is on.
            if ( !saveOnEveryTransaction ) {
                ColorConsole.WriteLine( "\t5. " + messageOutput [ MessageEnum.MainMenu_Load ] );
                ColorConsole.WriteLine( "\t6. " + messageOutput [ MessageEnum.MainMenu_Save ] );
                ColorConsole.Write( $"({messageOutput [ MessageEnum.SystemInstructions_PressToExit ]} : {messageOutput [ MessageEnum.SystemInstructions_EscapeOrBackspace ]})", colorByGroup [ ColorGroup.SystemInstructionsGray ] );
                ColorConsole.Write( $" {messageOutput [ MessageEnum.Label_Press ]} 1, 2, 3, 4, 5, {messageOutput [ MessageEnum.Label_Or ]} 6", colorByGroup [ ColorGroup.Default ], ResetColorAfter: false );
            } else {
                // Print instructions for main menu options when load and save options are not present
                ColorConsole.Write( $"({messageOutput [ MessageEnum.SystemInstructions_PressToExit ]} : {messageOutput [ MessageEnum.SystemInstructions_EscapeOrBackspace ]})", colorByGroup [ ColorGroup.SystemInstructionsGray ] );
                ColorConsole.Write( $" {messageOutput [ MessageEnum.Label_Press ]} 1, 2, 3, {messageOutput [ MessageEnum.Label_Or ]} 4", colorByGroup [ ColorGroup.Default ], ResetColorAfter: false );
            }
        }
        #endregion
    }
}
