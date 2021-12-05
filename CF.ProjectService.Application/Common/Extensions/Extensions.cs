using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CF.ProjectService.Application.Common.Extensions
{
    public class Extensions
    {

        public static bool HasChangedDifferentProperty<TSource, TDestination>(TSource source, TDestination destination, string propertySource, string propertyDestination)
        {
            if (propertySource != null && propertyDestination != null)
            {
                var newValue = source.GetType().GetProperty(propertySource).GetValue(source);
                var oldValue = destination.GetType().GetProperty(propertyDestination).GetValue(destination);

                if (!Equals(oldValue, newValue))
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Property string can not be null");
            }

            return false;
        }

        public static bool HasChangedSameProperties<TSource, TDestination>(TSource source, TDestination destination, params string[] propertyName)
             where TSource : class where TDestination : class
        {
            if (propertyName != null)
            {
                foreach (var property in propertyName)
                {
                    var newValue = source.GetType().GetProperty(property).GetValue(source);
                    var oldValue = destination.GetType().GetProperty(property).GetValue(destination);

                    if (!Equals(oldValue, newValue))
                    {
                        return true;
                    }
                }
            }
            else
            {
                throw new Exception("Property string can not be null");
            }

            return false;
        }

        public static bool HasChangedAllSameProperties<TSource, TDestination>(TSource source, TDestination destination, params string[] excepts)
             where TSource : class where TDestination : class
        {
            if (source != null && destination != null)
            {
                var listSourceProperties = source.GetType().GetProperties();
                foreach (var property in listSourceProperties)
                {
                    if (excepts.ToList().Contains(property.Name))
                    {
                        continue;
                    }

                    var newValue = property.GetValue(source);
                    if (destination.GetType().GetProperty(property.Name) != null)
                    {
                        var oldValue = destination.GetType().GetProperty(property.Name).GetValue(destination);
                        if (!Equals(oldValue, newValue))
                        {
                            return true;
                        }
                    }

                }
            }
            else
            {
                throw new Exception("Parameters can not be null");
            }

            return false;
        }

        public static bool HasChangedAll<TSource, TDestination>(TSource source, TDestination destination, Dictionary<string, string> listCompare)
             where TSource : class where TDestination : class
        {
            if (source != null && destination != null && listCompare != null)
            {
                foreach (var compare in listCompare)
                {
                    var newValue = source.GetType().GetProperty(compare.Key).GetValue(source);
                    var oldValue = destination.GetType().GetProperty(compare.Value).GetValue(destination);

                    if (!Equals(oldValue, newValue))
                    {
                        return true;
                    }
                }
            }
            else
            {
                throw new Exception("Parameters can not be null");
            }

            return false;
        }

        public static bool CheckAnyNullAllProperties(Object obj)
        {
            var listSourceProperties = obj.GetType().GetProperties();
            foreach (var property in listSourceProperties)
            {
                var value = property.GetValue(obj);
                if (value == null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
