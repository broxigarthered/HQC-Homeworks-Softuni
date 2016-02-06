namespace ChepelareHotelBookingSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Enums;
    using Identity;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    public abstract class Controller
    {
        protected Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Controller's current user.
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Boolean variable, which checks if there is a user current user.
        /// </summary>
        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        /// <summary>
        /// The application's data of all repositories.
        /// </summary>
        protected IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Creates an istance of a model, using reflection.
        /// </summary>
        /// <param name="model">Returns specific instance of type IView.</param>
        /// <returns></returns>
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamesapceSeparator);

            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamesapceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        /// <summary>
        /// Creates specific error message view.
        /// </summary>
        /// <param name="message">Specified message for the error.</param>
        /// <returns>Instance of type Error.</returns>
        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Check if given roles are authorized to perform certain action.
        /// </summary>
        /// <param name="roles">Enumeration of roles.</param>
        protected void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException("The currently logged in user doesn't have sufficient rights to perform this operation.", this.CurrentUser);
            }
        }
    }
}
