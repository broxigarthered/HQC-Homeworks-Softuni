namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using Infrastructure;

    using Models;

    public class Register : View
    {
        private User currentUser;

        public Register(User user)
            : base(user)
        {
            this.currentUser = user;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", this.currentUser.Username)
                .AppendLine();
        }
    }
}

