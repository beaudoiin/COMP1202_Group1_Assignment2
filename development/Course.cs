namespace assignment2 {
    //consider declaring property array declaring the menu title string and appropriate property.
    //or some similar way to pass to the caller the headings of a list display and the values fornthat column.
    // important if dynamically sizing the content to the window size.
    //allows using the same view for multiple object types.
    //see View all yransaction file and retrofit as oop which gayhers headings dynamicslly from 
    // the class it is displaying.
    ///Besure to add tripple slash summary
    internal class Course {
        //A list of the students enrolled in a specific course
        public List<Student>? EnrolledStudents { get; }
        //Besure to comment the two below
        public string? CourseName { get; set; }
        public int CreditHours { get; set; }

    }
}
