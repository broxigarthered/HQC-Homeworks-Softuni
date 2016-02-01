namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem;

    using Data;

    using Interfaces;

    using Models;

    using Theatre.Engine;
    using Theatre.Interfaces;

    public class BangaloreUniversityEngine : IBangaloreUniversityEngine
    {
        private IUserInterface userInterface;

        public BangaloreUniversityEngine()
            : this(new ConsoleUserInterface())
        {
            // DI: Added IUserInterface and ConsoleUserInterface types
            // and made the engine constructor take user interface using Dependency
        }

        private BangaloreUniversityEngine(ConsoleUserInterface consoleUserInterface)
        {
            this.userInterface = consoleUserInterface;
        }

        public void Run()
        {
            var dataBase = new BangaloreUniversityDate();
            User user = null;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                var route = new Route(line);
                var controllerType =
                    Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, dataBase, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, @params) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(parameterInfo =>
                {
                    if (parameterInfo.ParameterType == typeof(int))
                    {
                        return int.Parse(route.Parameters[parameterInfo.Name]);
                    }

                    return route.Parameters[parameterInfo.Name];
                }).ToArray();
        }
    }
}
