using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Models
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum enumValue)
        {
            var attribute = enumValue.GetType()
                          .GetField(enumValue.ToString())
                          .GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description;
        }
    }
}
