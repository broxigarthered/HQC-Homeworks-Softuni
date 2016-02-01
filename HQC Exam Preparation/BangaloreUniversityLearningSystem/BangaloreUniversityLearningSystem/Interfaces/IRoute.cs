namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface IRoute.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// The controller's name.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// The action's name.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Dictionary of key-value pair, where key and value are of type string.
        /// </summary>
        IDictionary<string, string> Parameters { get; set; }
    }
}
