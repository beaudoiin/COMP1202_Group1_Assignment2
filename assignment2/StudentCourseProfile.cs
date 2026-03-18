namespace assignment2 {
    public class StudentCourseProfile {
        Student Student { get; set; }
        Course Course { get; set; }
        Dictionary<string, float> Grades { get; set; }
        int CreditHours { get; set; }
        int AttendeeHours { get; set; }
        DateOnly RegistrationDate { get; set; }




        public StudentCourseProfile() {
        }
    }
}
