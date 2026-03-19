using System.Text.Json.Serialization;

namespace assignment2 {
    /// <summary>
    /// A class to define students enrolled in the college. This class creatues objects with unique IDs, names, emails and a list of the courses enrolled in.
    /// This summary is to be updated as this class is expanded.
    /// </summary>
    [Serializable]
    internal class Student {
        //UNIQUE incrimented ID. This is important to save and reset at every load, when loading students from a file.
        //Be sure to include this in the JSON string so that if 10 users are added, and number 9 is removed, the program wont start at 9 again or try to start at 0!
        private static int ID { get; set; } = 0;
        /// <summary>
        /// A unique ID for each student. you may want to consider using a 9 digit number as most institutions use.
        /// </summary>
        public int StudentId { get; set; }
        public string name { get; }
        //Email should be validated, impliment at a future date.
        public string email { get; }
        //A list of the students enrolled in a specific course
        public List<Course>? enrolledCourses { get; }
        /// <summary>
        /// Instantiate a new student
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        [JsonConstructor]
        public Student( string name, string email ) {
            this.name = name;
            this.email = email;
            StudentId = ID;
            ID++;
        }
        /// <summary>
        /// This may not be nesacarry as this is very redamentry. Remove if you are nopt planning on using genaric data (Ie, no advanced formatting)
        /// </summary>
        /// <returns></returns>
        public string toString() {
            return new string( "May Want To override" );
        }

    }
}