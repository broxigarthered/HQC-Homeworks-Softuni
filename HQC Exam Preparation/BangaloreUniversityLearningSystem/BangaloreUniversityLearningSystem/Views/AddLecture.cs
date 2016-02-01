namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;


    using Infrastructure;

    using Models;

    public class AddLecture : View
    {
        private Course currentCourse;

        public AddLecture(Course course)
            : base(course)
        {
            this.currentCourse = course;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("Lecture successfully added to course {0}.", this.currentCourse.Name)
                .AppendLine();
        }
    }
}
