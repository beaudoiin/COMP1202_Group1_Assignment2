using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace assignment2 {
    internal partial class Program {
        //THE BELOW CODE MAY APPEAR A BIT COMPLICATED, WE SHOULD DISCUSS IF WE WANT TO USE A PAGER AND IF WE DO I CAN TAKE CARE OF THIS. I STARTED MODIFYING IT BECASE
        //A LOT OF THIS WAS PASED ON LISTING TRANSACTIONS AND CHECKING THEIR STRING LENGTHS TO ENSURE ENOUGH SPACE, AND TRUNCATING THE DESCRIPTION TO FILL THE REST OF 
        // THE CONSOLE.WINDOW SIZE. THERE WAS DIFFERENT OPTIONS OF DISPLAY, SO SOME CODE IS BYPASSED OF TYPE IS NOT "PAGER".
        // USES CUSTOM ENUMS, AND MESSAGE DICTIONARIES AND SUCH. THE NUMEROUS ERRORS IS BECAUSE THIS WAS FROM ANOTHER PROGRAM AND NOT FULL OBJECT ORIENTED, SO IT
        // NEEDS SOME ADJUSTMENTS. THE AIM HERE IS TO MAKE THIS TAKE <T> TYPE, OR AN INTERFACE AND THEN IT JUST FORMATS EXPECTED DATA. FUTURE USE MEANS PROVIDING EXPECTED DATA
        // INSTEAD OF HARDCODING PROPERTIES THAT ARE EXPECTED. SEE ALL COMMENTS BELOW.
        // 
        // MOSTLY UNCHANGED VERSION CAN BE FOUND AT ViewTransactionsListExample.CS

        /// <summary>
        /// View all Object instances from a provided list. 
        /// Prompt user for Multiple viewing modes: Giant List, Pages, Both (Pages that don't clear the screen!)
        /// User navigates the Pages mode by using several keyboard shortcuts for back and forth.
        /// Banding is supported to make viewing esier.
        /// THIS MAY NEED SOME WORK TO ADD checking character code ranges that register as multi column characters and adjust/trucate to fit!
        /// Using <T> to allow for different lists to be passed.
        /// The better alternative for <T> is to use an itnerface that defines an ID, Array or structure so hold heading names and associated properties.
        /// Then the List becomes of the interface type, and anything implementing the interface can be passed to this method.
        /// (The assignment says not to use interface or inheritance so instead I opted to use <T>. We can throw an exception if the class doesnt define headers.)
        /// </summary>
        /// <param name="passedList">List holding the objects to be viewed</param>
        /// <param name="Label">Manu label suffex to specify a fine detail such as noting the different types such as "Courses" or "Students"</param>
        /// <param name="rearrangeList">Default you can sort by Name, if you want to feed it a preordered or unordered list dont specify anything</param>
        /// <param name="colorBand">True if you want results to have alternating background colors for each row</param>
        /// <remarks>This is currently a generic table display that does not use interfaces. To determine which data to show, each object will have a header list
        /// (labels for each property/field) and a method that returns a list of values in the same order as the headers.
        /// By keeping the header list and the method consistent in structure and naming across all types, the table display method can reliably work with any
        /// object without type-specific checks. Using an interface would be better, as it would enforce this structure for all implementing types.
        /// When displaying the table, we also calculate the maximum string length for each column, considering both the header and all data values (using LINQ).
        /// For example, if the "Name" column has values "A", "B", "C", "D" and "BOB", the column width will be 4 (length of "Name"). If a value like "Boberta"
        /// appears, the width increases to 7. We then add extra padding and a separator (e.g., " | ") to make the table visually consistent.</remarks>
        /// <returns></returns>
        private static bool ViewAllObjects<T>( List<T> passedList, string Label = "", bool rearrangeList = false, bool colorBand = true ) {


            //Clear screen using both ansi escape code and regular clear as a backup.
            Console.Write( "\x1b[3J" ); Console.Clear();

            //Set the defualt scroll type using an enum called ScrollType and it shoudl container Pager, List, Both, or somethign similar
            //Only if you want the default set
            ///ScrollType scroller = ScrollType.Pager; //Default Display Mode (my favourite)

            //No transactions to load
            if ( passedList.Count == 0 ) {
                //ColorConsole.WriteLine( $" {messageOutput [ MessageEnum.System_NoReleventTransactions ]} ", colorByGroup [ ColorGroup.SystemError ] );
                //Dynamically write the below to change items to "Students", "Courses", "Registrations", and mind your stricutre if using multi-langauge support
                //in such a case "(Students) There are none to show!" may be a better format to avoid gramatical issues.
                Console.WriteLine( "No items in the list" );
                AnyKeyToContinue( true );
                return false;
            }

            #region >>> /// This is for displaying a list view choice
            //Print the instructions on which pager to use, THIS IS ONLY USED IF YOU WANT TO MAKE PAGERS AND DIFFERENT WAYS TO VIEW THE LIST
            //MIND YOU A LOT OF CODE IS COMMENTED OUT BECAUSE IT IS BASED ON THIS PAGER VIEW SYSTEM
            /*
			ColorConsole.WriteLine( messageOutput [ MessageEnum.ReportAndSum_AskHowToView ], colorByGroup [ ColorGroup.Header ] );
			Console.WriteLine();
			ColorConsole.WriteLine( $"1. {messageOutput [ MessageEnum.ReportAndSum_Scroll ]}", colorByGroup [ ColorGroup.MenuItems ] );
			ColorConsole.WriteLine( $"2. {messageOutput [ MessageEnum.ReportAndSum_Pages ]}", colorByGroup [ ColorGroup.MenuItems ] );
			ColorConsole.WriteLine( $"3. {messageOutput [ MessageEnum.ReportAndSum_PageAndScrollNoClear ]}", colorByGroup [ ColorGroup.MenuItems ] );
			Console.WriteLine();
			ColorConsole.Write( $"({messageOutput [ MessageEnum.SystemInstructions_PressToExit ]} : {messageOutput [ MessageEnum.SystemInstructions_EscapeOrBackspace ]})", colorByGroup [ ColorGroup.SystemInstructionsGray ] );
			ColorConsole.Write( $" {messageOutput [ MessageEnum.Label_Press ]} : 1, 2, {messageOutput [ MessageEnum.Label_Or ]} 3 ", ConsoleColor.White );

			//Process user input
			while ( true ) {
				ConsoleKeyInfo key = Console.ReadKey( intercept: true );
				//User choose to exit
				if ( key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape )
					return false;
				if ( key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1 ) {
					scroller = ScrollType.Scroller;
					break;
				}
				if ( key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2 )
					break;//default initiatated at top
				if ( key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3 ) {
					scroller = ScrollType.Both;
					break;
				}
			}
			*/
            //Keep if previous printed a choice menu such as choosing pager
            Console.Write( "\x1b[3J" ); Console.Clear();
            #endregion

            #region >>> /// THIS is important for langauge translations. This is an example of checking a list of words that may be printed in the category
            ///This specifically was an example of checking the lengths of words for transaction categories and setting the max likley with of that column.
            //This actually writes out each item and checks its length. IMPORTANT for languages like Chinese, Hindi and others with charCodes that are multi columns
            /*Prvents mismatch in character column widths
			int maxLenCat = 0;
				ConsoleColor restoreForeground = Console.ForegroundColor;
				Console.ForegroundColor = Console.BackgroundColor;
				foreach ( var kv in TransactionCategoryToLanguage ) {
					string text = messageOutput [ kv.Value ];
					int start = Console.CursorLeft;
					Console.Write( text );
					int width = Console.CursorLeft - start;
					Console.CursorLeft = start; // reset cursor
					if ( width > maxLenCat )
						maxLenCat = width;
				}
				Console.ForegroundColor = restoreForeground;
				Console.Write( "\x1b[3J" ); Console.Clear();
			*/
            #endregion

            #region >>> //Sort by specified field into new list, you may need to check type to ensure to use the right property
            /*
             * List<T> SortedList = passedList;

            if ( rearrangeList )
                SortedTransactions.Sort( ( s1, s2 ) => s1.Date.CompareTo( s2.Date ) );
            //for checking length
            int maxLenAmount = 6; //this is a way to hardcode if you want the length, like we knw "Name" will always be 4, so that is the minimum, or starting max

            foreach ( Itterate through the instances in the list ) {
                //Formats as currency then captures the longest one
                int column1DataLength = obj.column1Data.Length;
                int column2DataLength = obj.column1Data.Length;
                // ...
                //Increases if Max amount is smaller update it, do this for each column data
                if ( column1DataMaxLength < column1DataLength )
					column1DataMaxLength = column1DataLength;
                // ...
            }
            */
            #endregion

            //This is relevent for languages like chinese where the word for Amount may be longer. (especially, longer than longest transaction)

            //height of the window before printing for page division (only for pager)
            int bufHeight = Console.WindowHeight;
            int listCount = sortedList.Count;


            int pgCount = 1;
            int nonitemLines = 4; //This is things like the header, any empty lines, a menu heading, any lines for instructions. basically any non table data
            int pgMax = listCount / ( bufHeight - nonitemLines );
            int pgRemainder = listCount % ( bufHeight - nonitemLines );
            if ( pgRemainder > 0 )
                pgMax++;
            //This is only if using pager, it just adjusts the heading title
            if ( scroller == ScrollType.Scroller )
                ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );
            else
                ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} ( {messageOutput [ MessageEnum.Label_PageAbreviated ]} : {pgCount}/{pgMax} ) {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );            //Length of Labels (based on language)

            //This checks the lengths of each category title, origonally from the language file incase some languages have longer spelling for "name".
            //this may not be needed if above you checked the longest amount, we can to this in above stage, together.
            int dateLabelLen = messageOutput [ MessageEnum.Label_Date ].ToString().Length;
            int amtLabelLen = messageOutput [ MessageEnum.Label_Amount ].ToString().Length;
            int descLabelLen = messageOutput [ MessageEnum.Label_Description ].ToString().Length;
            int catLabelLen = messageOutput [ MessageEnum.Label_Category ].ToString().Length;

            //Length of batting between items, later write line will use something like " | " 3 per item-1 = 9;
            string bodySpacer = "|  ";
            int headerSpacer = bodySpacer.Length + 2;
            int totalPaddingLength = headerSpacer * 3;

            //Overall padding available after longes printed items considered. (ie if the descriptions are short, or the amounts etc)
            //Mind you this below is for each column, and the maxLenDesc is the name of the one you are willing to truncate the most.
            //Desc just meant description.
            int maxLenDesc = Console.WindowWidth - ( maxLenAmount + maxLenCat + maxLenDate + totalPaddingLength );
            //Sepcify header padding lengths //Amout is last so padding not required
            int catLeftPos = maxLenDate + headerSpacer;
            int descLeftPos = maxLenCat + catLeftPos + headerSpacer;
            int amtLeftPos = maxLenDesc + descLeftPos + headerSpacer;
            //this was just to print the same header over and over, it will need to be retrofited to print from this new range of list object types.
            Writeheader();
            //Writes each transation formated with currency
            int lineCount = 1; //tracks how much each page held. used to set start index for each subequent page
            int evenodd = 0; //for color banding
            int i = 0;
            //Tracks each pages linecount printed, and length is the number of pages.
            int [ ] index_start_page = new int [ pgMax + 1 ];

            while ( true ) {
                //First line save index for Pager to track when moving back to this page. (if this page was 21, and when coming back, system knows to start printing 21)
                if ( lineCount == 1 )
                    index_start_page [ pgCount - 1 ] = i;
                //SCROLLER - Exit when whole list is printed and using scrolling tpye
                if ( i > SortedTransactions.Count - 1 && scroller == ScrollType.Scroller ) {
                    Console.ForegroundColor = colorByGroup [ ColorGroup.SystemInstructionsGray ] [ 0 ];
                    AnyKeyToContinue( msg: $"({messageOutput [ MessageEnum.Label_Press ]} {messageOutput [ MessageEnum.System_AnyKeyToExit ]})" );
                    // Use the ANSI escape sequence to clear the scrollback buffer
                    // Optional: Call Console.Clear() again to ensure a completely clean start, 
                    // as the escape sequence might leave the cursor on the second line.
                    Console.Write( "\x1b[3J" ); Console.Clear();

                    return true;
                }
                Transaction transaction = SortedTransactions.ElementAt( i ); //Get Transaction to print
                                                                             //Optional color banding. Defualt is active, otherwise use green
                if ( colorBand ) {
                    Console.ForegroundColor = evenodd == 0 ? ConsoleColor.Green : ConsoleColor.Cyan;
                    evenodd = ( evenodd == 0 ) ? 1 : 0;
                } else
                    if ( i == 0 )
                        Console.ForegroundColor = ConsoleColor.Green; //dont reset over and over if color banding is not on, it will already be green
                                                                      //Printing out Details in single row
                #region///Print Date Formated
                Console.Write( transaction.Date.ToString( dateFormatOut.Item1 ) );
                Console.Write( new string( ' ', maxLenDate - transaction.Date.ToString( dateFormatOut.Item1 ).Length ) + "  " + bodySpacer ); //sapcer
                #endregion
                #region ///Print Category        - Add spaces if not the max size, print spacer 3 chars
                Console.CursorLeft = catLeftPos;
                Console.Write( messageOutput [ TransactionCategoryToLanguage [ transaction.Category ] ] );
                //These no longer work due to chinese characters taking wide spaces
                //Max length - the actual legnth+ 3 for padding. So if the longest word is 12, and we have gas (3), should fill 9 spaces + 3 spaces.
                //if ( ( maxLenCat - Enum.GetName( transaction.Category ).Length ) > 0 )
                //    Console.Write( new string( ' ', maxLenCat - Enum.GetName( transaction.Category ).Length ) );
                //Console.Write( bodySpacer );
                Console.CursorLeft = descLeftPos - 3;
                Console.Write( bodySpacer );
                #endregion
                #region ///Print Description
                string descOutTrunc = transaction.Description;
                ///This method truncated strings that are too long, but some character mess up with length and cell width mismatch
                //if ( transaction.Description.ToString().Length > maxLenDesc - 3 ) {
                //    descOutTrunc = descOutTrunc.Substring( 0, maxLenDesc - 3 );
                //    Console.Write( descOutTrunc + "..." );
                //} else
                //    Console.Write( descOutTrunc );

                foreach ( char item in descOutTrunc ) {
                    if ( Console.CursorLeft > ( amtLeftPos - 9 ) ) {
                        Console.CursorLeft = amtLeftPos - 8;
                        Console.Write( "..." );
                        break;
                    } else {
                        Console.Write( item );
                    }

                }

                Console.CursorLeft = amtLeftPos - 3;


                Console.Write( bodySpacer );


                #endregion
                #region ///Print Amount
                Console.WriteLine( transaction.Amount.ToString( "C" ) );
                #endregion
                //Controll page changing
                if ( scroller == ScrollType.Pager || scroller == ScrollType.Both ) {
                    //Last Transaction on las page Printed
                    if ( pgCount == pgMax && i == SortedTransactions.Count - 1 ) {
                        //Sets the position to print this always at the bottom for consistancy
                        Console.CursorTop = Console.WindowHeight - 1;
                        ColorConsole.Write( messageOutput [ MessageEnum.SystemInstructions_PageView ], colorByGroup [ ColorGroup.SystemInstructionsGray ] );
                        //Update remainder to normalize the 0 in modulus
                        int remainder = ( pgRemainder == 0 ) ? ( bufHeight - nonitemLines ) : pgRemainder;
                        int toTop = 0;
                        //Navigation controls for the last page
                        while ( true ) {
                            ConsoleKeyInfo key = Console.ReadKey( true );
                            //Go back a page as long as its not page 1!
                            if ( pgMax != 1 && ( key.Key == ConsoleKey.PageUp || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.UpArrow ) ) {
                                pgCount--;
                                lineCount = 1;
                                i = index_start_page [ pgCount - 1 ];
                                toTop = 1;
                                //Clears if pager, but drops line for both because the instructions use Write which would allow menu on the same line
                                if ( scroller == ScrollType.Pager ) {
                                    Console.WriteLine();
                                    Console.Write( "\x1b[3J" ); Console.Clear();
                                } else {
                                    Console.WriteLine();
                                }
                                ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} ({messageOutput [ MessageEnum.Label_PageAbreviated ]} : {pgCount}/{pgMax} ) {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );
                                Writeheader();
                                break;
                            }
                            //exit by command
                            if ( key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Q ) {
                                toTop = 2;
                                break;
                            }
                        }
                        if ( toTop == 2 )
                            break;
                        if ( toTop == 1 )
                            continue;
                    }
                    #region ///Each Page finished except the last
                    if ( lineCount == bufHeight - nonitemLines ) {       //Screen full reset and print
                        lineCount = 0;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        ColorConsole.Write( messageOutput [ MessageEnum.SystemInstructions_PageView ], colorByGroup [ ColorGroup.SystemInstructionsGray ] );
                        int toTop = 0; //Used to track itteration of master for loop. (this scope)
                        while ( toTop == 0 ) {
                            ConsoleKeyInfo key = Console.ReadKey( true );
                            //Not first page (Can go back a page)
                            if ( pgCount > 1 && ( key.Key == ConsoleKey.PageUp || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.UpArrow ) ) {
                                pgCount--;
                                lineCount = 1;
                                i = index_start_page [ pgCount - 1 ];
                                toTop = 1;
                            }
                            if ( ( pgCount < pgMax && key.Key == ConsoleKey.PageDown ) || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.DownArrow ) {
                                pgCount++;
                                break; //bypass toTop control to print header
                            }
                            if ( key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Q )
                                toTop = 2;
                        }
                        //Clears if pager, but drops line for both because the instructions use Write which would allow menu on the same line
                        if ( scroller == ScrollType.Pager ) {
                            Console.Write( "\x1b[3J" ); Console.Clear();
                        } else {
                            Console.WriteLine();
                        }
                        ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} ({messageOutput [ MessageEnum.Label_PageAbreviated ]} : {pgCount}/{pgMax} ) {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );
                        Writeheader();
                        //Back to loop start with updated variables
                        if ( toTop == 1 ) {
                            toTop = 0;
                            continue;
                        }
                        //Exit
                        if ( toTop == 2 )
                            break;
                    }
                    #endregion
                }
                lineCount++;
                i++;
            }
            void Writeheader() {
                //Write the header
                ColorConsole.Write( messageOutput [ MessageEnum.Label_Date ], ConsoleColor.Red, ResetColorAfter: false );
                Console.CursorLeft = catLeftPos;
                Console.Write( messageOutput [ MessageEnum.Label_Category ] );
                Console.CursorLeft = descLeftPos;
                Console.Write( messageOutput [ MessageEnum.Label_Description ] );
                Console.CursorLeft = amtLeftPos;
                Console.WriteLine( messageOutput [ MessageEnum.Label_Amount ] );
                Console.WriteLine();
            }
            return false;
        }
    }
}
}
