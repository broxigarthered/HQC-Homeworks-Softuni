using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        #region constructors

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
        {
            Name = courseName;
            TeacherName = teacherName;
            Students = new List<string>();
        }
        #endregion

        #region properties
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }
        #endregion

        #region methods
        protected virtual string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
        #endregion
    }
}
