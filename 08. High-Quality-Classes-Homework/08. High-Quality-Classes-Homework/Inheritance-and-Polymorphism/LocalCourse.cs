using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        #region constructors
        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Lab = string.Empty;
        }

        public LocalCourse(string name) 
            : base(name)
        {
            this.Lab = string.Empty;
        }

        public LocalCourse(string courseName, string teacherName) 
            : base(courseName, teacherName)
        {
            this.Lab = string.Empty;
        }
        #endregion

        #region properties
        public string Lab { get; set; }
        #endregion

        #region methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
        #endregion
    }
}
