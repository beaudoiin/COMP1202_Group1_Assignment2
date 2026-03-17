namespace Assignment2 {
    /// <summary>
    /// Provides static methods for writing messages to the console with customizable foreground and background colors,
    /// supporting both single-line and multi-line output, as well as reading input with color changes.
    /// </summary>
    /// <remarks>The ColorConsole class enables enhanced console output by allowing developers to specify text
    /// and background colors for each message. Methods support optional color resets, user acknowledgment prompts, and
    /// flexible color configuration via parameters or arrays. This class is useful for creating visually distinct
    /// console applications and improving user interaction. All methods are thread-safe for typical console usage, but
    /// concurrent writes may result in interleaved output.</remarks>
    public class ColorConsole {

        /// <summary>
        /// Simply replace Console.Write with this to apply Foreground and Background color. Allows for Write and Write Line.
        /// Can be overloaded with a ConsoleColor array of 2 Count.
        /// </summary>
        /// <param name="msg">String to send to Console.Write(Line)</param>
        /// <param name="fg">Foregorund ConsoleColor</param>
        /// <param name="bg">Background ConsoleColor</param>
        /// <param name="WriteLine">Bool: true uses WriteLine false uses Write</param>
        /// <param name="ResetColorAfter">Resets the Color to before this method. True: resets (default), Fasle: leaves the color change</param>
        /// <param name="ColorAfterFg">Specify Foreground color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="ColorAfterBg">Specify background color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="WaitForAcknowledgment">Include a ReadKey and message that asks for the user to press any key to continue</param>
        public static void Write( string msg, ConsoleColor? fg = null, ConsoleColor? bg = null, bool WriteLine = false, bool ResetColorAfter = true, ConsoleColor? ColorAfterFg = null, ConsoleColor? ColorAfterBg = null, bool WaitForAcknowledgment = false ) {
            ConsoleColor fgReset = Console.ForegroundColor;
            ConsoleColor bgReset = Console.BackgroundColor;
            //only changes gf or background if color is supplied
            if ( fg != null )
                Console.ForegroundColor = ( ConsoleColor ) fg;
            if ( bg != null )
                Console.BackgroundColor = ( ConsoleColor ) bg;
            //simply writes the message depding on the flag. This allows for a method called WriteLine to change this (or manualy set)
            if ( WriteLine )
                Console.WriteLine( msg );
            else
                Console.Write( msg );
            if ( WaitForAcknowledgment ) {
                ColorConsole.WriteLine( $"\n({messageOutput [ MessageEnum.Label_Press ]} : {messageOutput [ MessageEnum.SystemInstructions_AnyKeyToAck ]})", colorByGroup [ ColorGroup.SystemInstructionsGray ] );
                Console.ReadKey( intercept: true );
            }
            if ( ColorAfterFg is not null )
                Console.ForegroundColor = ( ConsoleColor ) ColorAfterFg;
            else
                if ( ResetColorAfter )
                    Console.ForegroundColor = fgReset;
            if ( ColorAfterBg is not null )
                Console.BackgroundColor = ( ConsoleColor ) ColorAfterBg;
            else
                if ( ResetColorAfter )
                    Console.BackgroundColor = bgReset;
            if ( WaitForAcknowledgment )
                Console.Clear();
        }
        /// <summary>
        /// Simply replace Console.Write with this to apply Foreground and Background color. Allows for Write and Write Line.
        /// Can be overloaded with a ConsoleColor array of 2 Count.
        /// </summary>
        /// <param name="msg">String to send to Console.Write(Line)</param>
        /// <param name="colors">ConsoleColor Array of two items used for [0] Foreground ConsoleColor, and [1] Background ConsoleColor (any other indecies ignored)</param>
        /// <param name="ResetColorAfter">Resets the Color to before this method. True: resets (default), Fasle: leaves the color change</param>
        /// <param name="ColorAfterFg">Specify Foreground color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="ColorAfterBg">Specify background color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="WaitForAcknowledgment">Include a ReadKey and message that asks for the user to press any key to continue</param>
        public static void Write( string msg, ConsoleColor [ ] colors, bool ResetColorAfter = true, ConsoleColor? ColorAfterFg = null, ConsoleColor? ColorAfterBg = null, bool WaitForAcknowledgment = false ) {
            //ensure there is an index populated and pass color otherwise use null
            ConsoleColor? fg = ( colors.Length > 0 ) ? colors [ 0 ] : null;
            ConsoleColor? bg = ( colors.Length > 1 ) ? colors [ 1 ] : null;
            Write( msg, fg, bg, WriteLine: false, ResetColorAfter, ColorAfterFg: ColorAfterFg, ColorAfterBg: ColorAfterBg, WaitForAcknowledgment: WaitForAcknowledgment );
        }
        /// <summary>
        /// Simply replace Console.Write with this to apply Foreground and Background color. Allows for Write Line only.
        /// This just calls Write with a true boolean to use WriteLine.
        /// </summary>
        /// <param name="msg">String to send to Console.Write(Line)</param>
        /// <param name="fg">Foregorund ConsoleColor</param>
        /// <param name="bg">Background ConsoleColor</param>
        /// <param name="WriteLine">Bool: true uses WriteLine false uses Write, defualt is WriteLine</param>
        /// <param name="ResetColorAfter">Resets the Color to before this method. True: resets (default), Fasle: leaves the color change</param>
        ///<param name="ColorAfterFg">Specify Foreground color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="ColorAfterBg">Specify background color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="WaitForAcknowledgment">Include a ReadKey and message that asks for the user to press any key to continue</param>
        public static void WriteLine( string msg, ConsoleColor? fg = null, ConsoleColor? bg = null, bool WriteLine = false, bool ResetColorAfter = true, ConsoleColor? ColorAfterFg = null, ConsoleColor? ColorAfterBg = null, bool WaitForAcknowledgment = false ) {
            Write( msg, fg, bg, WriteLine: true, ResetColorAfter: ResetColorAfter, ColorAfterFg: ColorAfterFg, ColorAfterBg: ColorAfterBg, WaitForAcknowledgment: WaitForAcknowledgment );
        }
        /// <summary>
        /// Simply replace Console.Write with this to apply Foreground and Background color. Allows for Write Line only.
        /// This just calls Write with a true boolean to use WriteLine.
        /// </summary>
        /// <param name="msg">String to send to Console.Write(Line)</param>
        /// <param name="colors">ConsoleColor Array of two items used for [0] Foreground ConsoleColor, and [1] Background ConsoleColor (any other indecies ignored)></param>
        /// <param name="ResetColorAfter">Resets the Color to before this method. True: resets (default), Fasle: leaves the color change</param>
        ///<param name="ColorAfterFg">Specify Foreground color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="ColorAfterBg">Specify background color after the line is writen and Awknowledge (if specified) is done.</param>
        ///<param name="WaitForAcknowledgment">Include a ReadKey and message that asks for the user to press any key to continue</param>
        public static void WriteLine( string msg, ConsoleColor [ ] colors, bool ResetColorAfter = true, ConsoleColor? ColorAfterFg = null, ConsoleColor? ColorAfterBg = null, bool WaitForAcknowledgment = false ) {
            ConsoleColor? fg = ( colors.Length > 0 ) ? colors [ 0 ] : null;
            ConsoleColor? bg = ( colors.Length > 1 ) ? colors [ 1 ] : null;
            Write( msg, fg, bg, WriteLine: true, ResetColorAfter, ColorAfterFg: ColorAfterFg, ColorAfterBg: ColorAfterBg, WaitForAcknowledgment: WaitForAcknowledgment );
        }
        /// <summary>
        /// Replaces ReadLine with a ConsoleColor change from an array of 2 ConsoleColors, first is Foregound, second is Bakcground, any other indecies are ignored.
        /// </summary>
        /// <param name="colors">ConsoleColor array, index 0: FG, Index 1: BG</param>
        ///  <param name="returnColorFg">specify Foreground color to change to when done</param>
        /// <param name="returnColorBg">specify Background color to change to when done</param>
        /// <returns>non-null string from ReadLine</returns>
        public static string ReadLine( ConsoleColor [ ] colors, ConsoleColor? returnColorBg = null, ConsoleColor? returnColorFg = null ) {
            ConsoleColor fgReset = Console.ForegroundColor;
            ConsoleColor bgReset = Console.BackgroundColor;
            bool colorsMin2 = false;
            //Protecting reading index when it doesnt exit, sets background only if supplied
            Console.ForegroundColor = colors [ 0 ]!;
            Console.BackgroundColor = colors [ 1 ]!;
            Console.CursorVisible = true;
            string msg = Console.ReadLine()!;
            Console.CursorVisible = false;
            //Change to specified foreground if supplied, if not, use reset if foreground was used, if not leave foregorund alone.
            //State of ConsoleColor.Foreground after readline
            Console.ForegroundColor = returnColorFg is not null ? ( ConsoleColor ) returnColorFg : fgReset;
            //Change to specified background if supplied, if not, use reset if background was used, if not leave background alone.
            //State of ConsoleColor.Background after readline
            if ( returnColorBg is not null )
                Console.BackgroundColor = ( ConsoleColor ) returnColorBg;
            else if ( colorsMin2 )
                Console.BackgroundColor = bgReset;
            return msg;
        }
        /// <summary>
        /// Replaces ReadLine and Overloaded to use no params, or 2 Console Color params, Foreground and Background.
        /// </summary>
        /// <param name="fg">Foreground ConsoleColor</param>
        /// <param name="bg">Background ConsoleColor</param>
        /// <param name="returnColorFg">specify Foreground color to change to when done</param>
        /// <param name="returnColorBg">specify Background color to change to when done</param>
        /// <returns>non-null string from ReadLine</returns>
        public static string ReadLine( ConsoleColor? fgNullable = null, ConsoleColor? bgNullable = null, ConsoleColor? returnColorBg = null, ConsoleColor? returnColorFg = null ) {
            ConsoleColor fg = fgNullable ?? Console.ForegroundColor;
            ConsoleColor bg = bgNullable ?? Console.BackgroundColor;
            var fgbg = new ConsoleColor [ ] { fg, bg };
            return ReadLine( fgbg );
        }
    }
}
