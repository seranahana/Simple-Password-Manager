using System.Reflection;

namespace SimplePM.Library
{
    public static class MethodInfoExtensions
    {
        public static string GetParamName(this MethodInfo method, int index)
        {
            string retVal = string.Empty;
            if (method is not null && method.GetParameters().Length > index)
            {
                retVal = method.GetParameters()[index].Name;
            }
            return retVal;
        }
    }
}
