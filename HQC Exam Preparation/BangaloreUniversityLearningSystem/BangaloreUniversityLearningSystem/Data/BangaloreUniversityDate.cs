namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;
    using Models;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public BangaloreUniversityDate()
        {
            this.Users = new UsersRepository();
            this.Course = new Repository<Course>();
        }

        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Course { get; protected set; }
    }
}
