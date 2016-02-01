namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Exceptions;

    using Enums;
    using Interfaces;
    using Models;

    using Utilities;

    public abstract class Controller
    {
        private bool hasCurrentUser;

        protected Controller(IBangaloreUniversityDate data, User user)
        {
            this.User = user;
            this.Data = data;
        }

        #region properties
        public bool HasCurrentUser
        {
            get
            {
                return this.User != null;
            }

            set
            {
                this.hasCurrentUser = value;
            }
        }

        public User User { get; set; }

        protected IBangaloreUniversityDate Data { get; set; }
        #endregion

        #region methods
        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var user in this.Data.Users.GetAll())
            {
                if (!roles.Any(role => user.IsInRole(role)))
                {
                    throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
                }
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            baseNamespace = "BangaloreUniversityLearningSystem";
            // string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + actionName;

            // BUG - It was taking wrong assembly name.
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }
        #endregion
    }
}
