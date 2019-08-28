using System.Collections.Generic;

namespace Majin.Vegeta.Build.Extensions
{
    /// <summary>
    /// ExpandoObject extension methods.
    /// </summary>
    public static class DynamoExtensions
    {
        /// <summary>
        /// Add Property to Dynamic Object or updates existing value in case of existence
        /// </summary>
        /// <param name="expandoDict">IDictionary</param>
        /// <param name="propertyName">property name to Add</param>
        /// <param name="propertyValue">property value</param>
        public static void AddProperty(this IDictionary<string, object> expandoDict, string propertyName, object propertyValue)
        {
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
