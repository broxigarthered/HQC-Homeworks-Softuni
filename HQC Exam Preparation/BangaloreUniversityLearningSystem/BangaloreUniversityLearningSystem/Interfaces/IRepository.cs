namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains methods for getting all the courses in the repository, getting a concrete course
    /// by its ID and adding courses.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all courses in the repository.
        /// </summary>
        /// <returns>Returns the courses in appropriate order and "No courses." message if there are no courses</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>Returns the course in appropriate format.</returns>
        T Get(int id);

        /// <summary>
        /// A method for adding a given course to the repository.
        /// </summary>
        /// <param name="item">The course.</param>
        void Add(T item);
    }
}
