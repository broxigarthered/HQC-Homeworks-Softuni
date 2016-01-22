using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        #region constructors
        public OffsiteCourse(string name, string teacherName, IList<string> students) 
            : base(name, teacherName, students)
        {
            this.Town = string.Empty;
        }

        public OffsiteCourse(string name)
            : base(name)
        {
            this.Town = string.Empty;
        }

        public OffsiteCourse(string courseName, string teacherName) 
            : base(courseName, teacherName)
        {
            this.Town = string.Empty;
        }
        #endregion

        #region properties
        public string Town { get; set; }
        #endregion

        #region methods

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
        #endregion

        
    }
}
