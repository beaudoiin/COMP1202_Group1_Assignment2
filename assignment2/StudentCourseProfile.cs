namespace assignment2 {
    class StudentCourseProfile {

        /// <summary>
        /// Contains the student for this relationship
        /// </summary>
        Student Student { get; set; }
        /// <summary>
        /// Contains the course of this relationshi0p
        /// </summary>
        Course Course { get; set; }
        /// <summary>
        /// Containes a dictionary of each lab,assignment, etc grade.
        /// </summary>
        Dictionary<string, float> Grades { get; set; }
        /// <summary>
        /// Date the user registered for this course
        /// </summary>
        DateOnly RegistrationDate { get; set; }
        /// <summary>
        /// Constructor for creating a relationship entity
        /// </summary>
        /// <param name="student">Student associated in this relationship</param>
        /// <param name="course">Course associated in this relatioship</param>
        /// <param name="registrationDate">Date the student Registered</param>
        StudentCourseProfile( Student student, Course course, DateOnly registrationDate ) {
            Student = student;
            Course = course;
            RegistrationDate = registrationDate;
        }

    }
}
