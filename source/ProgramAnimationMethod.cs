namespace assignment2 {
    /// <summary>
    /// Man program defined as partial for splitting some methods into other files. Merges back at compile time
    /// </summary>
    internal partial class Program {
        #region >>> /// Helper Methods for sample data and Prompts to pause program flow.
        /// <summary>
        /// Uses threadSleep to pause the screen for a short period of time and clear any ConsoleKeys that may be buffered.
        /// </summary>
        /// <param name="ms">Duration in ms to halt main thread</param>
        /// <param name="clearScreen">True: use Console.Clear() after</param>
        static void ThreadSleepAndClearKeys( int ms = 500, bool clearScreen = false ) {
            Thread.Sleep( ms );
            while ( Console.KeyAvailable )
                Console.ReadKey( true );
            if ( clearScreen ) {
                Console.Write( "\x1b[3J" ); Console.Clear();
            }
        }
        //The bottom is only an example, it is not needed for this program but can be used as a template for animating the programs intro. Update as needed.
        /// <summary>
        /// Animates the logo of the Cornerstone Financial Management System in the console with a multi-pass visual
        /// effect, transitioning from monochrome to color and displaying system information.
        /// </summary>
        /// <remarks>The animation consists of several frames rendered over three passes, each with
        /// distinct color schemes and timing. The system's name and creator details are displayed as part of the
        /// animation. This method is intended for introductory or branding purposes and does not return a
        /// value.</remarks>
        static void IntroAnimation() {
            ConsoleColor introColorPyrmid = ConsoleColor.Gray;
            ConsoleColor introColorText = ConsoleColor.Gray;
            int introAnimationMs = 160;
            (int Left, int Top) cornersonePos = (0, 0);
            string cornerFMS = "Cornerstone Financial Management System";
            ConsoleColor? pyramidColor = null;
            //Animates the logo for 3 passes, one black and white, another with color and the third is coloring a portion
            for ( int i = 1; i < 4; i++ ) {
                Console.SetCursorPosition( 0, 0 );
                if ( i == 2 ) {
                    introColorPyrmid = ConsoleColor.DarkYellow;
                    introColorText = ConsoleColor.Gray;
                    introAnimationMs = 120;
                }
                if ( i == 3 ) {
                    pyramidColor = ConsoleColor.White;
                    introAnimationMs = 80;
                }
                //Writes portions so the background can be changed, also sets cursor position for the next foreach and while loop for color changing of what is written already.
                ColorConsole.Write( "         ▄█", introColorPyrmid );
                ColorConsole.Write( "▀", introColorPyrmid, ResetColorAfter: true, bg: pyramidColor ); //this gets changed
                ColorConsole.WriteLine( "▄", introColorPyrmid );
                ThreadSleepAndClearKeys( introAnimationMs );
                ColorConsole.Write( "       ▄██", introColorPyrmid );
                ColorConsole.Write( "▀▀▀▀", introColorPyrmid, ResetColorAfter: true, bg: pyramidColor ); // gets changed
                ColorConsole.Write( "▄", introColorPyrmid );
                ColorConsole.Write( "\t\t" );
                cornersonePos = Console.GetCursorPosition();
                ColorConsole.WriteLine( cornerFMS, introColorText );
                introAnimationMs -= 10;
                ThreadSleepAndClearKeys( introAnimationMs );
                ColorConsole.Write( "     ▄███", introColorPyrmid );
                ColorConsole.Write( "▀▀▀▀▀▀▀", introColorPyrmid, ResetColorAfter: true, bg: pyramidColor );//gets changed
                ColorConsole.Write( "▄", introColorPyrmid );
                ColorConsole.WriteLine( "\t    Created By : Eric Beaudoin", introColorText );
                introAnimationMs -= 10;
                ThreadSleepAndClearKeys( introAnimationMs );
                ColorConsole.Write( "   ▄████", introColorPyrmid );
                ColorConsole.Write( "▀▀▀▀▀▀▀▀▀▀", introColorPyrmid, ResetColorAfter: true, bg: pyramidColor );// gets changed
                ColorConsole.Write( "▄", introColorPyrmid );
                ColorConsole.WriteLine( "\t    http://www.CornerPi.com", introColorText );
                introAnimationMs -= 10;
                ThreadSleepAndClearKeys( introAnimationMs );
                ColorConsole.Write( " ▄█████", introColorPyrmid );
                ColorConsole.Write( "▀▀▀▀▀▀▀▀▀▀▀▀▀", introColorPyrmid, ResetColorAfter: true, bg: pyramidColor );// gets changed
                ColorConsole.WriteLine( "▄", introColorPyrmid );

                ThreadSleepAndClearKeys( introAnimationMs );
            }
            pyramidColor = ConsoleColor.White;
            ColorConsole.WriteLine( "Press any key to continue", ConsoleColor.Gray );
            //Blinks a square while waiting
            Console.SetCursorPosition( cornersonePos.Left, cornersonePos.Top );
            foreach ( char e in cornerFMS ) {
                ThreadSleepAndClearKeys( 10 );
                ColorConsole.Write( e.ToString(), ConsoleColor.Cyan );
            }
            bool exitLoopTmp = false;
            //Loops flashing a character background on the buffer window, and if the user presses any key it exits.
            //broke the 500ms into chunks to allow instant reading. with a small time buffer so it doesnt happen to quick.
            while ( true ) {
                for ( int i = 0; i < 50; i++ ) {
                    Thread.Sleep( 10 );
                    if ( Console.KeyAvailable ) {
                        ConsoleKeyInfo key = Console.ReadKey( true );
                        exitLoopTmp = true;
                        break;
                    }
                }
                pyramidColor = ( pyramidColor == ConsoleColor.Black ) ? ConsoleColor.White : ConsoleColor.Black;
                if ( exitLoopTmp ) {
                    ThreadSleepAndClearKeys( 250 ); // adds a slight delay
                    break;
                }
                Console.SetCursorPosition( 11, 0 );

                ColorConsole.Write( "▀", introColorPyrmid, pyramidColor, ResetColorAfter: true );

            }
            #region ///Initializing for formating
            Console.ForegroundColor = colorByGroup [ ColorGroup.Default ] [ 0 ]; //Console Color Default Set
            Console.BackgroundColor = colorByGroup [ ColorGroup.Default ] [ 1 ]; //incase color/information from previous program carried over
            Console.WriteLine( " " ); //helps clear any artifacts from usin colors with Write
            #endregion
        }

-

        /// <summary>
        /// //ChatGpt Tool for converting languages quickly, Converts a dictionary to xml. read comments inside
        /// Not currently in use, this is a DEV tool, just like sampleData (which is in use)
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="twoCharLanguageCode"></param>
        /// <param name="filePath"></param>
        private static void ExportLanguageFile() {
            string twoCharLanguageCode = "hi";   // change when generating another language, the last one I did was hindi.

            Dictionary<MessageEnum, string> english = defaultEnglishMessages;
            Dictionary<MessageEnum, string> lang = new() {
                //Translate the enire english dictionary keys and strings exactly to here in a new language. This will format to XML, and you can copy that
                //into the language file. Good for using AI to present data in simple dictionary add statements. AI can manage translations better that way.
                //This method was used to generate the 7 languages seen here. Modifactions can be done and updates using regex directly on the file after, or
                //use this.
            };
            bool error = false;

            if ( english.Count != lang.Count ) {
                Console.WriteLine( $"Dictionary size mismatch! English={english.Count} Lang={lang.Count}" );
                error = true;
            }

            foreach ( var key in english.Keys ) {
                if ( !lang.ContainsKey( key ) ) {
                    Console.WriteLine( $"Missing key: {key}" );
                    error = true;
                }
            }

            foreach ( var key in lang.Keys ) {
                if ( !english.ContainsKey( key ) ) {
                    Console.WriteLine( $"Extra key in language file: {key}" );
                    error = true;
                }
            }

            if ( error ) {
                Console.WriteLine( "\nDictionary mismatch detected. Press any key to halt." );
                Console.ReadKey( true );
                return;
            }

            using StreamWriter writer = new( "language_export.xml" );

            writer.WriteLine( $"<{twoCharLanguageCode}>" );

            string currentGroup = "";

            foreach ( var pair in lang.OrderBy( p => p.Key.ToString() ) ) {
                string key = pair.Key.ToString();
                string value = pair.Value;

                int split = key.IndexOf( '_' );
                string group = split > 0 ? key.Substring( 0, split ) : key;

                if ( group != currentGroup ) {
                    writer.WriteLine( $"<!-- {group} -->" );
                    currentGroup = group;
                }

                writer.WriteLine( $"  <item key=\"{key}\">" );
                writer.WriteLine( $"      <message>{value}</message>" );
                writer.WriteLine( $"  </item>" );
            }

            writer.WriteLine( $"</{twoCharLanguageCode}>" );
        }
        #endregion
    }
}