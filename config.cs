namespace Assignment2 {
    /// <summary>
    /// Simple configuration file for saving the language so the user doesn't have to type it in each time.
    /// Review instances where this is used to ensure when extending nothing is overwritten.
    /// </summary>
    public class Configuration {
        public string language { get; set; } = "en";
        public Configuration( string language = "en" ) {
            this.language = language;
        }
    }
}
