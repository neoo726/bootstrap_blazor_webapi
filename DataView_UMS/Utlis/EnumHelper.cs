using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Utlis
{
    public static class EnumHelper
    {
        public static int GetEnumIntValue<T>(T enumValue) where T : Enum
        {
            return Convert.ToInt32(enumValue);
        }
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>枚举值的描述</returns>
        public static string GetEnumDescription(Enum value)
        {
            // 获取枚举值的类型信息
            Type type = value.GetType();

            // 获取枚举项的名称
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            // 获取枚举项的字段信息
            FieldInfo field = type.GetField(name);
            if (field == null)
            {
                return null;
            }

            // 获取DescriptionAttribute特性
            var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                           .FirstOrDefault() as DescriptionAttribute;

            if (descriptionAttribute == null)
            {
                return null;
            }

            // 使用资源管理器获取对应的文本
            //var resourceManager = new ResourceManager(type.Namespace, type.Assembly);
            //string description = resourceManager.GetString(descriptionAttribute.Description, CultureInfo.CurrentUICulture);

            //return description ?? descriptionAttribute.Description;
            return descriptionAttribute.Description;
        }
        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T ConvertToEnum<T>(string val)
        {
            return (T)Enum.Parse(typeof(T), val, true);
        }
    }
}
