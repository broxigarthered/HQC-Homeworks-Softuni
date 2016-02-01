namespace BangaloreUniversityLearningSystem.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BangaloreUniversityLearningSystem.Infrastructure;

    using Models;

    public class All : View
    {
        private IEnumerable<Course> currentCourses;

        public All(IEnumerable<Course> courses)
            : base(courses)
        {
            this.currentCourses = courses;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.currentCourses as IEnumerable<Course>;
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count).AppendLine();
                }
            }
        }
    }
}
