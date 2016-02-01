namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Login : View
    {
        private User currentUser;

        public Login(User user)
            : base(user)
        {
            this.currentUser = user;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", this.currentUser.Username)
                .AppendLine();
        }
    }
}
