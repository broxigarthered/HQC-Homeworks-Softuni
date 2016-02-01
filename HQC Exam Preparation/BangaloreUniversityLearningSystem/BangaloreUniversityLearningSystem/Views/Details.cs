namespace BangaloreUniversityLearningSystem.Views
{
    using System;
    using System.Linq;
    using System.Text;


    using Infrastructure;

    using Models;

    public class Details : View
    {
        private Course model;

        public Details(Course course)
            : base(course)
        {
            this.model = course;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.model as Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = this.model.Lectures.Select(lecture => "- " + lecture.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}
