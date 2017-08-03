using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Produtos.Infraestrutura.Extensions
{
    public static class EnumExtensions
    {
        public static string ObterDescricao(this System.Enum enumerador)
        {
            MemberInfo[] memberInfo = enumerador.GetType().GetMember(enumerador.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] atributos = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).ToArray();

                if (atributos != null && atributos.Length > 0)
                    return ((DescriptionAttribute)atributos[0]).Description;
            }
            return enumerador.ToString();
        }

        public static IEnumerable<T> ComoIEnumerable<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<T> ComoIEnumerableIgnorandoValorDefault<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Where(enumItem => Convert.ToInt32(enumItem) > 0);
        }
    }
}
