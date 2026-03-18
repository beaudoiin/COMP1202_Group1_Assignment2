namespace assignment2 {
    internal class College {
        #region /// Method 1 for storing Student/Course relationship - 2 dictionaries
        //Good for who clearly belonds to who, bad for storing additional information.
        //may be good to have a StudentCourseProfile as the object where information for that specific course is held. 
        //Links a student to a course and their grade information.

        //Stores the List of students per course
        public static Dictionary<Course, List<Student>> CourseHasWhatStudents;
        //Stores the list of courses per student
        public static Dictionary<Student, List<Course>> StudentHasWhatCourses;
        #endregion

        #region /// Method 2 for storing Student/Course relationship - Array of objects, professors prefrence
        //This stores the profile that contains the student and the registration. When adding a new student or course we track these with lists, and simply allow null if not registerd
        //There is some benefit to this but you still have to track which student and course is being talked about.
        StudentCourseProfile? [ , ] StudentCourseEnrollment;
        #endregion

        public College() {
        }
    }
}