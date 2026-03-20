using Assignment1;

namespace Assignment2 {
    internal class ViewTransactionsListExample {
        /// <summary>
        /// View all transactions from a provided list. 
        /// Prompt user for Multiple viewing modes: Giant List, Pages, Both (Pages that don't clear the screen!)
        /// User navigates the Pages mode by using several keyboard shortcuts for back and forth.
        /// Banding is supported to make viewing esier.
        /// THIS NEEDS SOME WORK TO ADD checking character code ranges that register as multi column characters and adjust/trucate to fit!
        /// </summary>
        /// <param name="passedTransactions">List holding the transactions to be viewed</param>
        /// <param name="Label">Manu label suffex to specify a fine detail such as noting the different types such as "expense" or "income"</param>
        /// <param name="rearrangeList">Default you can sort by date, incase you want to feed it an unordered list dont specify anything</param>
        /// <param name="colorBand">True if you want results to have alternating background colors for each row</param>
        /// <returns></returns>
        private static bool ViewTransactions( List<Transaction> passedTransactions, string Label = "", bool rearrangeList = false, bool colorBand = true ) {
            //adds spacing if a label is added if not don't take any extra space
            Label = string.IsNullOrEmpty( Label ) ? "" : System.String.Concat( " ", Label );
            ScrollType scroller = ScrollType.Pager; //Default Display Mode (my favourite)
            Console.Write( "\x1b[3J" ); Console.Clear();
            //No transactions to load
            if ( passedTransactions.Count == 0 ) {
                ColorConsole.WriteLine( $" {messageOutput [ MessageEnum.System_NoReleventTransactions ]} ", colorByGroup [ ColorGroup.SystemError ] );
                AnyKeyToContinue( true );
                //This may have been missing a return false;
            }
            //Print the instructions
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
            //Told chang gpt what I wanted for this snipit, I assumed I didnt want to write to the screen
            //like I did in the transaction print out, but I guess thats the best way.
            //Prvents mismatch in character column widths
            int maxLenCat = 0;
            Console.Write( "\x1b[3J" ); Console.Clear();
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
            //Sort by date into new list
            List<Transaction> SortedTransactions = passedTransactions;
            if ( rearrangeList )
                SortedTransactions.Sort( ( s1, s2 ) => s1.Date.CompareTo( s2.Date ) );
            //for checking length
            int maxLenAmount = 6;

            //May appear unnesscary, but if we change setting in other part of program for long dates we will still space out properly.
            int maxLenDate = dateFormatOut.Item2; //2nd item in touple is integer of the length. Using long names returns september as longest
            //A better approach would be to check length with every added item and store it, and only do this once on file load.
            foreach ( Transaction transaction in SortedTransactions ) {
                //Formats as currency then captures the longest one
                int amountLen = transaction.Amount.ToString( "C" ).Length;
                int catLen = Enum.GetName( transaction.Category ).Length;
                //Increases if Mac amount is smaller
                if ( maxLenAmount < amountLen )
                    maxLenAmount = amountLen;
            }
            //This is relevent for languages like chinese where the word for Amount may be longer. (especially, longer than longest transaction)

            //height of the window before printing for overflow
            int bufHeight = Console.WindowHeight;
            int pgCount = 1;
            int nonitemLines = 4;
            int pgMax = SortedTransactions.Count / ( bufHeight - nonitemLines );
            int pgRemainder = SortedTransactions.Count % ( bufHeight - nonitemLines );
            if ( pgRemainder > 0 )
                pgMax++;
            if ( scroller == ScrollType.Scroller )
                ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );
            else
                ColorConsole.WriteLine( $"{messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]} {messageOutput [ MessageEnum.TransMgnt_ViewAllTransactions ]}{Label} ( {messageOutput [ MessageEnum.Label_PageAbreviated ]} : {pgCount}/{pgMax} ) {messageOutput [ MessageEnum.Menu_HeaderOuterDecor ]}", colorByGroup [ ColorGroup.Header ] );            //Length of Labels (based on language)
            int dateLabelLen = messageOutput [ MessageEnum.Label_Date ].ToString().Length;
            int amtLabelLen = messageOutput [ MessageEnum.Label_Amount ].ToString().Length;
            int descLabelLen = messageOutput [ MessageEnum.Label_Description ].ToString().Length;
            int catLabelLen = messageOutput [ MessageEnum.Label_Category ].ToString().Length;
            //Length of batting between items, later write line will use something like " | " 3 per item-1 = 9;
            string bodySpacer = "|  ";
            int headerSpacer = bodySpacer.Length + 2;
            int totalPaddingLength = headerSpacer * 3;
            //Overall padding available after longes printed items considered. (ie if the descriptions are short, or the amounts etc)
            int maxLenDesc = Console.WindowWidth - ( maxLenAmount + maxLenCat + maxLenDate + totalPaddingLength );
            //Sepcify header padding lengths //Amout is last so padding not required
            int catLeftPos = maxLenDate + headerSpacer;
            int descLeftPos = maxLenCat + catLeftPos + headerSpacer;
            int amtLeftPos = maxLenDesc + descLeftPos + headerSpacer;
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
