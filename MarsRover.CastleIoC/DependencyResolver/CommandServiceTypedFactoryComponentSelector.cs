using Castle.Facilities.TypedFactory;
using System.Reflection;

namespace MarsRover.CastleIoC.DependencyResolver
{
    public class CommandServiceTypedFactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            if (method.Name.EndsWith("CommandService"))
            {
                return method.Name;
            }
            return base.GetComponentName(method, arguments);
        }
    }
}
