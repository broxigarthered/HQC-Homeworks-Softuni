namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;


    using Infrastructure;
    using Models;

    public class Logout : View
    {
        private User currentUser;

        public Logout(User user)
            : base(user)
        {
            this.currentUser = user;
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.", this.currentUser.Username)
                .AppendLine();
        }
    }
}
