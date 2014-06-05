using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace PTO.Core
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description of the specified enum type.
        /// </summary>
        /// <param name="enumName">The enum type value.</param>
        /// <returns>A string containing the text of the enum description</returns>
        public static string GetDescription(Enum enumName)
        {
            if (enumName == null)
            {
                throw new ArgumentNullException("enumName");
            }

            Type type = enumName.GetType();

            MemberInfo[] memInfo = type.GetMember(enumName.ToString());

            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumName.ToString();
        }

        /// <summary>
        /// Converts the specified Enum type to an IList of enum value and description name value pair.
        /// </summary>
        /// <param name="type">The Enum type.</param>
        /// <returns>An IList containing the enumerated type value and description.</returns>
        public static IList ToList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
    }
}
