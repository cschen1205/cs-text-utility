using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TextUtility
{
    public class XmlUtil
    {
        public static TEnum GetParameterEnumValue<TEnum>(Dictionary<string, string> parameters, string param_name, TEnum default_value)
            where TEnum : struct
        {
            if (parameters.ContainsKey(param_name))
            {
                TEnum result;
                if (Enum.TryParse<TEnum>(parameters[param_name], out result))
                {
                    return result;
                }
            }
            return default_value;
        }

        public static double GetParameterDoubleValue(Dictionary<string, string> parameters, string param_name, double default_value)
        {
            if (parameters.ContainsKey(param_name))
            {
                double result;
                if (double.TryParse(parameters[param_name], out result))
                {
                    return result;
                }
            }
            return default_value;
        }

        public static int GetParameterIntValue(Dictionary<string, string> parameters, string param_name, int default_value)
        {
            if (parameters.ContainsKey(param_name))
            {
                int result;
                if (int.TryParse(parameters[param_name], out result))
                {
                    return result;
                }
            }
            return default_value;
        }

        public static bool GetParameterBoolValue(Dictionary<string, string> parameters, string param_name, bool default_value)
        {
            if (parameters.ContainsKey(param_name))
            {
                bool result;
                if (bool.TryParse(parameters[param_name], out result))
                {
                    return result;
                }
            }
            return default_value;
        }

        public static string GetParameterStringValue(Dictionary<string, string> parameters, string param_name, string default_value)
        {
            if (parameters.ContainsKey(param_name))
            {
                return parameters[param_name];
            }
            return default_value;
        }

        public static void AppendAttribute(XmlElement parent, XmlDocument doc, string name, object value)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = value.ToString();
            parent.Attributes.Append(attr);
        }

        public static void AppendParameter(XmlElement parent, XmlDocument doc, string name, object value)
        {
            XmlElement param = doc.CreateElement("param");

            AppendAttribute(param, doc, "name", name);
            AppendAttribute(param, doc, "value", value);
            parent.AppendChild(param);
        }

        public static Dictionary<string, string> GetParameters(XmlElement parent, XmlDocument doc)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlNodeList nlist = parent.GetElementsByTagName("param");
            foreach (XmlElement nelement in nlist)
            {
                string param_name = nelement.Attributes["name"].Value;
                string param_value = nelement.Attributes["value"].Value;
                parameters[param_name] = param_value;
            }
            return parameters;
        }

    }
}
