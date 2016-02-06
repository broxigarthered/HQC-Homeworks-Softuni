namespace ChepelareHotelBookingSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using Data;
    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    public class Engine : IEngine
    {
        private IUserInterface userInterface;

        public Engine()
            : this(new ConsoleUserInterface())
        {
            // DI: Added IUserInterface and ConsoleUserInterface types
            // and made the engine constructor take user interface using Dependency
        }

        public Engine(ConsoleUserInterface consoleUserInterface)
        {
            this.userInterface = consoleUserInterface;
        }

        public void StartOperation()
        {
            var database = new HotelBookingSystemData();
            User currentUser = null;
            while (true)
            {
                string url = this.userInterface.ReadLine();

                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                this.userInterface.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            //TODO possible bottleneck
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(executionEndpoint.Parameters[p.Name], Constants.DateFormat, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return executionEndpoint.Parameters[p.Name];
                    }
                })
               .ToArray();

            return parameters;
        }
    }
}
