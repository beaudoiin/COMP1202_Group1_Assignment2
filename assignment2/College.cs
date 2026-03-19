namespace assignment2 {
    internal class College {
        #region /// Method 1 for storing Student/Course relationship - 2 dictionaries
        //Good for who clearly belonds to who, bad for storing additional information.
        //may be good to have a StudentCourseProfile as the object where information for that specific course is held. 
        //Links a student to a course and their grade information.

        //Comments may be out of sync check above and other method
        public static required List<Student> Students { get; set; }
        public static required List<Course> Courses { get; set; }
        public static required List<StudentCourseProfile> StudentCourseProfiles { get; set; }

        #endregion

        #region /// Method 2 for storing Student/Course relationship - Array of objects, professors prefrence
        //This stores the profile that contains the student and the registration. When adding a new student or course we track these with lists, and simply allow null if not registerd
        //There is some benefit to this but you still have to track which student and course is being talked about.
        //StudentCourseProfile? [ , ] StudentCourseEnrollment;
        #endregion

        public College() {
        }
    }
}