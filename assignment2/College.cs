namespace assignment2 {
    internal class College {
        #region /// Method 1 for storing Student/Course relationship - 2 dictionaries
        //Good for who clearly belonds to who, bad for storing additional information.
        //may be good to have a StudentCourseProfile as the object where information for that specific course is held. 
        //Links a student to a course and their grade information.

        //Stores the List of students per course
        public static required Dictionary<Course, List<Student>> CourseHasWhatStudents;
        //Stores the list of courses per student
        public static required Dictionary<Student, List<Course>> StudentHasWhatCourses;
        #endregion

        #region /// Method 2 for storing Student/Course relationship - Array of lists
        //Populate this because using indexes in 2d array seems dumb. Good for only once source of thruth bad for tracking specifics in my opinion.
        #endregion

    }
}