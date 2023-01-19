using System;
using System.Collections.Generic;

namespace CSharpUtils.DataProcessing
{
    public static class ObjectMapper
    {
        // in memory cache of all available mapping functions
        private static Dictionary<Type, Dictionary<Type, Func<object, object>>> maps = new Dictionary<Type, Dictionary<Type, Func<object, object>>>();

        public static ToType Map<ToType>(object obj)
        {
            Type toType = typeof(ToType);
            Type fromType = obj.GetType();

            if (maps.ContainsKey(fromType))
            {
                if (maps[obj.GetType()].ContainsKey(toType))
                {
                    return (ToType)maps[fromType][toType].Invoke(obj);
                }
            }

            throw new Exception("Type mapping not found");
        }

        public static bool IsRegistered(Type toType, Type fromType)
        {
            if (!maps.ContainsKey(toType))
            {
                return false;
            }

            return maps[toType].ContainsKey(fromType);
        }

        public static bool RegisterMap<FromType, ToType>(Func<FromType, ToType> mappingFunction)
        {
            Type toType = typeof(ToType);
            Type fromType = typeof(FromType);

            if (!maps.ContainsKey(fromType))
            {
                maps.Add(fromType, new Dictionary<Type, Func<object, object>>());
            }

            if (!maps[fromType].ContainsKey(toType))
            {
                maps[fromType].Add(toType, new Func<object, object>((x) => mappingFunction.Invoke((FromType)x)));

                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}