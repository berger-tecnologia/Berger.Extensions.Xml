﻿using System.Xml.Linq;
using System.Xml.Serialization;

namespace Berger.Extensions.Xml
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(this string input)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
        public static DateTime ToDateTime(this XElement e)
        {
            if (e == null)
                return DateTime.MinValue;

            else if (string.IsNullOrEmpty(e.Value))
                return DateTime.MinValue;

            else
                return DateTime.Parse(e.Value);
        }
        public static string FromElementToString(this XElement e)
        {
            if (e == null)
                return string.Empty;

            else if (string.IsNullOrEmpty(e.Value))
                return string.Empty;

            else
                return e.Value;
        }
        public static int FromElementToInt(this XElement e)
        {
            if (e == null)
                throw new InvalidCastException("Invalid cast.");
            else if (string.IsNullOrEmpty(e.Value))
                throw new InvalidCastException("Invalid cast.");
            else
                return int.Parse(e.Value.ToString());
        }
        public static string FromAttributeToString(this XAttribute e)
        {
            if (e == null)
                return string.Empty;
            else
                return e.Value;
        }
        public static int FromAttributeToInt(this XAttribute e)
        {
            if (e == null)
                throw new InvalidCastException("Invalid cast.");
            else
                return int.Parse(e.Value.ToString());
        }
    }
}