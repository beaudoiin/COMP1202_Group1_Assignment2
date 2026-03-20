//Requires console color code
namespace assignment2 {
    /// <summary>
    /// Man program defined as partial for splitting some methods into other files. Merges back at compile time
    /// </summary>
    internal partial class Program {
        /// <summary>
        /// Prints a reusable message and asks the user to press any key to continue. This is for convenience.
        /// User can also supply a message if they want. Default is to use a dictionary item by enum 
        /// messageOutput[MessageEnum.PressAnyKeyToContinue]
        /// </summary>
        /// <param name="ClearAfter">True if you want to clear the screen after</param>
        /// <param name="BypassMsg">True if you dont want to print the suplpied message</param>
        /// <param name="WriteLine">True if you want this to be on its own line</param>
        public static void AnyKeyToContinue( bool ClearAfter = false, bool BypassMsg = false, bool WriteLine = true, string msg = "", bool DontChangeColor = false ) {

            if ( string.IsNullOrWhiteSpace( msg ) )
                //msg = $"({messageOutput [ MessageEnum.Label_Press ]} {messageOutput [ MessageEnum.System_AnyKeyToContinue ]})";
                msg = $"(Press any key to continue)";
            if ( !BypassMsg )
                if ( WriteLine ) {
                    if ( DontChangeColor == true )
                        ColorConsole.WriteLine( msg, ConsoleColor.Gray );
                    else
                        ColorConsole.WriteLine( msg );
                } else {
                    if ( DontChangeColor == true )
                        Console.Write( msg, ConsoleColor.Gray );
                    else
                        Console.Write( msg );
                }

            Console.ReadKey( true );
            if ( ClearAfter ) {
                //Escape code to clear history outside of console buffer size, prevents some issues on modern systems, however if ansi escape not supported
                //it will just print the text, which is why I clear after words just incase. I dont want to test if they support ansi first, for a trivial reason.
                Console.Write( "\x1b[3J" ); Console.Clear();
            }
        }
    }
}