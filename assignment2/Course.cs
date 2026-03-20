using System.Text.Json.Serialization;

namespace assignment2 {
    //consider declaring property array declaring the menu title string and appropriate property.
    //or some similar way to pass to the caller the headings of a list display and the values fornthat column.
    // important if dynamically sizing the content to the window size.
    //allows using the same view for multiple object types.
    //see View all yransaction file and retrofit as oop which gayhers headings dynamicslly from 
    // the class it is displaying.
    ///Besure to add tripple slash summary
    [Serializable]
    internal class Course {
        //Id generator for creating unique IDS
        [JsonInclude]
        private static int s_CourseIDGenerator = 0;
        //Unique identifier for the course
        public int CourseID { get; set; }
        //A list of the students enrolled in a specific course
        public List<Student>? EnrolledStudents { get; }

        /*
         * Consider adding AppointedProfessors, or similar as a list, and create a professor class.
         * consider adding a specific class that extends this and adds the above professor list and dates and times for the course. semester offered and such.
        */

        //Besure to comment the two below
        public string CourseName { get; set; }
        public int CreditHours { get; set; }
        public string Description { get; set; }
        [JsonConstructor]
        public Course( string courseName, int creditHours, string? desctription = null ) {
            CourseName = courseName;
            CreditHours = creditHours;
            CourseID = ++s_CourseIDGenerator;
            Description = string.IsNullOrWhiteSpace( desctription ) ? "No descirption provided at this point in time." : desctription;
        }
        /// <summary>
        /// Display some details about the course without formatting.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $"Course: {CourseName}, ID: {CourseID}, Credit Hours: {CreditHours}, No. of enrolled students: {EnrolledStudents.Count}";
        }
    }
}